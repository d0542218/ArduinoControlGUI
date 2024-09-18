#include <patterns.h>
#include <WiFi.h>
const char *ssid = "Lab543";
const char *password = "cculab543";
// const char *ssid = "AILab";
// const char *password = "ailab120";
const IPAddress serverIP(192, 168, 1, 114); // 欲訪問的地址
uint16_t serverPort = 8888;                 // 伺服器埠號
String s;

const int latchPin = 17;  // Latch pin (STCP腳位)
const int latchPin1 = 16; // Latch pin (STCP腳位)
const int latchPin2 = 4;  // Latch pin (STCP腳位)
const int latchPin3 = 2;  // Latch pin (STCP腳位)
const int clockPin = 22;  // Clock pin (SHCP腳位)
const int dataPin = 33;   // Data pin (DS腳位)
// const int dataPin1 = 25;   // Data pin (DS腳位)
// const int dataPin2 = 26;   // Data pin (DS腳位)
// const int dataPin3 = 27;   // Data pin (DS腳位)
const int latchPinArray[4] = {latchPin3, latchPin2, latchPin1, latchPin};
// const int latchPinArray[4] = {latchPin, latchPin1, latchPin2, latchPin3};
// const int dataPinArray[4] = { dataPin, dataPin1, dataPin2, dataPin3 };

int t = 0; // delay time
int interval = 10;

unsigned long start;
unsigned long finish;
unsigned long start_total;
unsigned long finish_total;
unsigned long serial_time;

// IPAddress ip(192,168,1,120);
// IPAddress gateway(192,168,1,1);
// IPAddress subnet(255,255,255,0);

IPAddress local_IP(192, 168, 1, 1);
IPAddress gateway(192, 168, 1, 1);
IPAddress subnet(255, 255, 255, 0);

WiFiClient client; // 聲明一個客戶端對象，用於與伺服器進行連接

template <typename T>
void defaultpatterns(const T *patterns, int inc, int ref, int num1, int num2);
int pinNum(int num1);
int count_shiftOut(int num1, int num2, int pin);
void all_on_off(String beamType, int num1, int num2);
void shiftOut_RIS(uint8_t dataPin, uint8_t clockPin, uint8_t val);
void splitString(String info, int num1, int num2);

void setup()
{
  Serial.begin(115200);
  Serial.println();
  WiFi.mode(WIFI_AP_STA);
  Serial.println("Configuring soft-AP...");
  WiFi.softAPConfig(local_IP, gateway, subnet);
  WiFi.softAP(ssid, password); // 设置成AP模式
  Serial.print("AP IP address: ");
  Serial.println(WiFi.softAPIP());
  Serial.print("softAP macAddress: ");
  Serial.println(WiFi.softAPmacAddress());
  Serial.println("Server started.....");
  Serial.println("Test start...");

  //  WiFi.config(ip,gateway,subnet);
  //  setup_wifi();

  // Set all the pins of 74HC595 as OUTPUT
  pinMode(latchPin, OUTPUT);
  pinMode(latchPin1, OUTPUT);
  pinMode(latchPin2, OUTPUT);
  pinMode(latchPin3, OUTPUT);
  pinMode(dataPin, OUTPUT);
  pinMode(clockPin, OUTPUT);
  // Initial pins
  digitalWrite(latchPin, LOW);
  digitalWrite(latchPin1, LOW);
  digitalWrite(latchPin2, LOW);
  digitalWrite(latchPin3, LOW);
  digitalWrite(dataPin, LOW);
  digitalWrite(clockPin, LOW);
}

void setup_wifi()
{
  delay(10);
  // We start by connecting to a WiFi network
  Serial.println();
  Serial.print("Connecting to ");
  Serial.println(ssid);
  WiFi.begin(ssid, password); // connect to WiFi
  while (WiFi.status() != WL_CONNECTED)
  { // If WiFi connect failed
    delay(500);
    Serial.print(".");
  }
  Serial.println();
  Serial.println("WiFi connected");
  Serial.println("IP address: ");
  Serial.println(WiFi.localIP());
}

void loop()
{

  //  Serial.println("嘗試訪問伺服器");
  if (client.connect(serverIP, serverPort)) // 嘗試訪問目標地址
  {
    // Serial.println("訪問成功");
    while (client.connected() || client.available())
    { // 如果已連接或有收到的未讀取的數據
      delay(0);
      int index_1, index_2, inc, ref, num1, num2, delayTime;
      String str, beamType;

      if (client.available()) // 如果有數據可讀取
      {
        start_total = millis();
        // Serial.print("start_total = ");
        // Serial.println(start_total);
        String cmd = client.readStringUntil('\n'); // 讀取數據到換行符
        client.println("1");                       // 讀取到數據
        // Serial.println(cmd);

        index_1 = cmd.indexOf('_');
        inc = cmd.substring(0, index_1).toInt(); // 入射角

        index_2 = cmd.indexOf('_', index_1 + 1);
        ref = cmd.substring(index_1 + 1, index_2).toInt(); // 反射角

        index_1 = index_2;
        index_2 = cmd.indexOf('_', index_1 + 1);
        beamType = cmd.substring(index_1 + 1, index_2); // beam的種類和模式

        index_1 = index_2;
        index_2 = cmd.indexOf('_', index_1 + 1);
        num1 = cmd.substring(index_1 + 1, index_2).toInt();

        index_1 = index_2;
        index_2 = cmd.indexOf('_', index_1 + 1);
        num2 = cmd.substring(index_1 + 1, index_2).toInt();

        index_1 = index_2;
        index_2 = cmd.lastIndexOf(';');
        str = cmd.substring(index_1 + 1, index_2);

        delayTime = cmd.substring(cmd.indexOf(';') + 1).toInt();

        if (beamType == "default") // 預設pattern
        {
          if (num1 == 40) // 40*40
            defaultpatterns(p_40_40, inc, ref, num1, num2);
          else if (num1 == 32) // 32*64
            defaultpatterns(p_32_64, inc, ref, num1, num2);
        }
        else if (beamType == "allnfind")
        {
          Serial.println("All find!");
          for (int r = -60; r <= 60; r += 10) // 掃描一次
          {
            Serial.print("The angle of reflection is ");
            Serial.print(r);
            Serial.println(" deg");

            if (num1 == 40) // 40*40
              defaultpatterns(p_40_40, inc, r, num1, num2);
            else if (num1 == 32) // 32*64
              defaultpatterns(p_32_64, inc, r, num1, num2);
            else if (num1 == 20) // 20*20
            {
              // defaultpatterns(p_20_20, inc, r, num1, num2);
              Serial.println("No such pattern!");
              break;
            }

            if (r < 60)
              delay(delayTime);
          }
        }
        else if (beamType == "allon" || beamType == "alloff")
          all_on_off(beamType, num1, num2);

        else // 自定義pattern
          splitString(str, num1, num2);

        finish_total = millis();
        serial_time = finish_total - start_total;
        Serial.print("Running_time_total ");
        Serial.print(serial_time);
        Serial.println("ms!");
      }
    }

    // Serial.println("關閉當前連接");
    client.stop(); // 關閉客戶端
  }
  else
  {
    // Serial.println("訪問失敗");
    // ESP.restart();
    //     client.stop(); //關閉客戶端
  }

  delay(0);
}

// 預設patterns函數，會根據面鏡大小、inc和ref找到對應的pattern
template <typename T>
void defaultpatterns(const T *patterns, int inc, int ref, int num1, int num2)
{
  int idx1, idx2 = 0;
  int pin = pinNum(num1);
  int count = count_shiftOut(num1, num2, pin);

  // 尋找對應的pattern
  for (idx1 = 0; idx1 < NUM_PATTERNS; idx1++)
    if (patterns[idx1].inc == inc && patterns[idx1].ref == ref)
      break;

  if (idx1 == NUM_PATTERNS)
  {
    Serial.println("No such pattern!");
    return;
  }

  for (int i = 0; i < pin; i++)
  {
    if (i > 0)
      delay(t);

    digitalWrite(latchPinArray[i], LOW);
    for (int j = 1; j <= count; j++)
      shiftOut_RIS(dataPin, clockPin, patterns[idx1].data[idx2++]);
    digitalWrite(latchPinArray[i], HIGH);
  }
}

// 計算用到的latchPin數量，若是20*20則為1，若是40*40或32*64則為4
int pinNum(int num1)
{
  int pin = 0;

  if (num1 == 20) // 20*20
    pin = 1;
  else if (num1 == 40 || num1 == 32) // 40*40 or 32*64
    pin = 4;

  return pin;
}

// 計算要跑幾次shiftOut
int count_shiftOut(int num1, int num2, int pin)
{
  return num1 * num2 / pin / 8;
}

// 運行 all on 和 all off 模式的函數
void all_on_off(String beamType, int num1, int num2)
{
  int value;
  int pin = pinNum(num1);
  int count = count_shiftOut(num1, num2, pin);

  if (beamType == "allon")
  {
    Serial.println("ALL ON!");
    value = 255;
  }
  else
  {
    Serial.println("ALL OFF!");
    value = 0;
  }

  for (int i = 0; i < pin; i++)
  {
    if (i > 0)
      delay(t);

    digitalWrite(latchPinArray[i], LOW);
    for (int j = 1; j <= count; j++)
      shiftOut_RIS(dataPin, clockPin, value);
    digitalWrite(latchPinArray[i], HIGH);
  }
}

// 經過改寫的shiftOut函數
void shiftOut_RIS(uint8_t dataPin, uint8_t clockPin, uint8_t val)
{
  // 預設都是MSBFIRST
  uint8_t i;

  // digitalWrite(clockPin, LOW);
  for (i = 0; i < 8; i++)
  {
    // digitalWrite(dataPin, (val & 128) != 0);
    digitalWrite(dataPin, !!(val & (1 << (7 - i))));

    delayMicroseconds(5);
    digitalWrite(clockPin, HIGH);
    delayMicroseconds(5);
    digitalWrite(clockPin, LOW);
  }
}

// 自定義patterns函數，將接收到的字串分割成三個字元一組，並送給RIS
void splitString(String info, int num1, int num2)
{
  int value, idx = 0;
  int pin = pinNum(num1);
  int count = count_shiftOut(num1, num2, pin);
  String hexStr;

  for (int i = 0; i < pin; i++)
  {
    if (i > 0)
      delay(t);

    digitalWrite(latchPinArray[i], LOW);
    for (int j = 1; j <= count; j++, idx += 3)
    {
      value = info.substring(idx, idx + 3).toInt();
      shiftOut_RIS(dataPin, clockPin, value);
    }
    digitalWrite(latchPinArray[i], HIGH);
  }
}

// 以下為廢棄的函數
/*
void splitString(String info, int num) {
  // int start = millis();
  int latchPin, dataPin;  // 將latchPin和dataPin重新宣告為區域變數，以區別全域變數
  num = num * num / 400;  // 單元數量 num × num 再除8，再除50，計算外層迴圈要跑的次數
  int value, idx = 0;

  for (int i = num - 1; i >= 0; i--) {
    latchPin = latchPinArray[i];
    dataPin = dataPinArray[i];

    if (i < num - 1)
      delay(t);

    digitalWrite(latchPin, LOW);             // 送資料前要先把 latchPin 設成低電位
    for (int j = 1; j <= 50; j++, idx += 3)  // 內層迴圈固定跑50次shiftOut
    {
      value = info.substring(idx, idx + 3).toInt();
      shiftOut_RIS(dataPin, clockPin, value);
      // shiftOut(dataPin, clockPin, MSBFIRST, value);
      // testInfo(idx, value);
    }
    digitalWrite(latchPin, HIGH);  // 送完資料後要把 latchPin 設成高電位
  }
  // int finish = millis();
  // Serial.println(finish - start);
}
*/

/*
void outputToRIS(int inc, int ref, String type) // 依入射和反射角輸出對應的pattern給RIS
{
  Serial.print("The angle of reflection is ");
  Serial.print(ref);
  Serial.println(" deg");

  // 現改為inc固定為0度。ref從-60到60度，間隔10度。type固定窄beam。共13張patterns
  if (inc == 0)
  {
    switch (ref)
    {
    case 60: // incident 0 deg,reflection 60 deg
    {
      digitalWrite(latchPin3, LOW);
      shiftOut_RIS(dataPin, clockPin, 192);
      shiftOut_RIS(dataPin, clockPin, 254);
      shiftOut_RIS(dataPin, clockPin, 3);
      shiftOut_RIS(dataPin, clockPin, 240);
      shiftOut_RIS(dataPin, clockPin, 31);
      shiftOut_RIS(dataPin, clockPin, 193);
      shiftOut_RIS(dataPin, clockPin, 223);
      shiftOut_RIS(dataPin, clockPin, 7);
      shiftOut_RIS(dataPin, clockPin, 226);
      shiftOut_RIS(dataPin, clockPin, 15);
      shiftOut_RIS(dataPin, clockPin, 3);
      shiftOut_RIS(dataPin, clockPin, 207);
      shiftOut_RIS(dataPin, clockPin, 143);
      shiftOut_RIS(dataPin, clockPin, 131);
      shiftOut_RIS(dataPin, clockPin, 129);
      shiftOut_RIS(dataPin, clockPin, 15);
      shiftOut_RIS(dataPin, clockPin, 131);
      shiftOut_RIS(dataPin, clockPin, 252);
      shiftOut_RIS(dataPin, clockPin, 29);
      shiftOut_RIS(dataPin, clockPin, 240);
      shiftOut_RIS(dataPin, clockPin, 252);
      shiftOut_RIS(dataPin, clockPin, 56);
      shiftOut_RIS(dataPin, clockPin, 17);
      shiftOut_RIS(dataPin, clockPin, 240);
      shiftOut_RIS(dataPin, clockPin, 31);
      shiftOut_RIS(dataPin, clockPin, 255);
      shiftOut_RIS(dataPin, clockPin, 207);
      shiftOut_RIS(dataPin, clockPin, 240);
      shiftOut_RIS(dataPin, clockPin, 3);
      shiftOut_RIS(dataPin, clockPin, 0);
      shiftOut_RIS(dataPin, clockPin, 255);
      shiftOut_RIS(dataPin, clockPin, 199);
      shiftOut_RIS(dataPin, clockPin, 240);
      shiftOut_RIS(dataPin, clockPin, 3);
      shiftOut_RIS(dataPin, clockPin, 224);
      shiftOut_RIS(dataPin, clockPin, 255);
      shiftOut_RIS(dataPin, clockPin, 192);
      shiftOut_RIS(dataPin, clockPin, 0);
      shiftOut_RIS(dataPin, clockPin, 15);
      shiftOut_RIS(dataPin, clockPin, 255);
      shiftOut_RIS(dataPin, clockPin, 248);
      shiftOut_RIS(dataPin, clockPin, 32);
      shiftOut_RIS(dataPin, clockPin, 15);
      shiftOut_RIS(dataPin, clockPin, 252);
      shiftOut_RIS(dataPin, clockPin, 63);
      shiftOut_RIS(dataPin, clockPin, 0);
      shiftOut_RIS(dataPin, clockPin, 127);
      shiftOut_RIS(dataPin, clockPin, 255);
      shiftOut_RIS(dataPin, clockPin, 3);
      shiftOut_RIS(dataPin, clockPin, 0);
      digitalWrite(latchPin3, HIGH);
      delay(t);
      digitalWrite(latchPin2, LOW);
      shiftOut_RIS(dataPin, clockPin, 3);
      shiftOut_RIS(dataPin, clockPin, 207);
      shiftOut_RIS(dataPin, clockPin, 207);
      shiftOut_RIS(dataPin, clockPin, 7);
      shiftOut_RIS(dataPin, clockPin, 224);
      shiftOut_RIS(dataPin, clockPin, 252);
      shiftOut_RIS(dataPin, clockPin, 56);
      shiftOut_RIS(dataPin, clockPin, 49);
      shiftOut_RIS(dataPin, clockPin, 242);
      shiftOut_RIS(dataPin, clockPin, 15);
      shiftOut_RIS(dataPin, clockPin, 7);
      shiftOut_RIS(dataPin, clockPin, 195);
      shiftOut_RIS(dataPin, clockPin, 248);
      shiftOut_RIS(dataPin, clockPin, 28);
      shiftOut_RIS(dataPin, clockPin, 124);
      shiftOut_RIS(dataPin, clockPin, 224);
      shiftOut_RIS(dataPin, clockPin, 207);
      shiftOut_RIS(dataPin, clockPin, 143);
      shiftOut_RIS(dataPin, clockPin, 5);
      shiftOut_RIS(dataPin, clockPin, 240);
      shiftOut_RIS(dataPin, clockPin, 248);
      shiftOut_RIS(dataPin, clockPin, 62);
      shiftOut_RIS(dataPin, clockPin, 15);
      shiftOut_RIS(dataPin, clockPin, 195);
      shiftOut_RIS(dataPin, clockPin, 192);
      shiftOut_RIS(dataPin, clockPin, 255);
      shiftOut_RIS(dataPin, clockPin, 192);
      shiftOut_RIS(dataPin, clockPin, 0);
      shiftOut_RIS(dataPin, clockPin, 124);
      shiftOut_RIS(dataPin, clockPin, 255);
      shiftOut_RIS(dataPin, clockPin, 0);
      shiftOut_RIS(dataPin, clockPin, 63);
      shiftOut_RIS(dataPin, clockPin, 254);
      shiftOut_RIS(dataPin, clockPin, 3);
      shiftOut_RIS(dataPin, clockPin, 192);
      shiftOut_RIS(dataPin, clockPin, 255);
      shiftOut_RIS(dataPin, clockPin, 0);
      shiftOut_RIS(dataPin, clockPin, 15);
      shiftOut_RIS(dataPin, clockPin, 252);
      shiftOut_RIS(dataPin, clockPin, 0);
      shiftOut_RIS(dataPin, clockPin, 255);
      shiftOut_RIS(dataPin, clockPin, 192);
      shiftOut_RIS(dataPin, clockPin, 240);
      shiftOut_RIS(dataPin, clockPin, 124);
      shiftOut_RIS(dataPin, clockPin, 127);
      shiftOut_RIS(dataPin, clockPin, 1);
      shiftOut_RIS(dataPin, clockPin, 207);
      shiftOut_RIS(dataPin, clockPin, 240);
      shiftOut_RIS(dataPin, clockPin, 5);
      shiftOut_RIS(dataPin, clockPin, 255);
      digitalWrite(latchPin2, HIGH);
      delay(t);
      digitalWrite(latchPin1, LOW);
      shiftOut_RIS(dataPin, clockPin, 255);
      shiftOut_RIS(dataPin, clockPin, 255);
      shiftOut_RIS(dataPin, clockPin, 192);
      shiftOut_RIS(dataPin, clockPin, 0);
      shiftOut_RIS(dataPin, clockPin, 3);
      shiftOut_RIS(dataPin, clockPin, 255);
      shiftOut_RIS(dataPin, clockPin, 255);
      shiftOut_RIS(dataPin, clockPin, 128);
      shiftOut_RIS(dataPin, clockPin, 0);
      shiftOut_RIS(dataPin, clockPin, 31);
      shiftOut_RIS(dataPin, clockPin, 255);
      shiftOut_RIS(dataPin, clockPin, 192);
      shiftOut_RIS(dataPin, clockPin, 12);
      shiftOut_RIS(dataPin, clockPin, 3);
      shiftOut_RIS(dataPin, clockPin, 255);
      shiftOut_RIS(dataPin, clockPin, 7);
      shiftOut_RIS(dataPin, clockPin, 192);
      shiftOut_RIS(dataPin, clockPin, 31);
      shiftOut_RIS(dataPin, clockPin, 255);
      shiftOut_RIS(dataPin, clockPin, 240);
      shiftOut_RIS(dataPin, clockPin, 128);
      shiftOut_RIS(dataPin, clockPin, 63);
      shiftOut_RIS(dataPin, clockPin, 240);
      shiftOut_RIS(dataPin, clockPin, 60);
      shiftOut_RIS(dataPin, clockPin, 3);
      shiftOut_RIS(dataPin, clockPin, 192);
      shiftOut_RIS(dataPin, clockPin, 193);
      shiftOut_RIS(dataPin, clockPin, 243);
      shiftOut_RIS(dataPin, clockPin, 243);
      shiftOut_RIS(dataPin, clockPin, 224);
      shiftOut_RIS(dataPin, clockPin, 224);
      shiftOut_RIS(dataPin, clockPin, 195);
      shiftOut_RIS(dataPin, clockPin, 225);
      shiftOut_RIS(dataPin, clockPin, 251);
      shiftOut_RIS(dataPin, clockPin, 193);
      shiftOut_RIS(dataPin, clockPin, 240);
      shiftOut_RIS(dataPin, clockPin, 7);
      shiftOut_RIS(dataPin, clockPin, 192);
      shiftOut_RIS(dataPin, clockPin, 126);
      shiftOut_RIS(dataPin, clockPin, 7);
      shiftOut_RIS(dataPin, clockPin, 124);
      shiftOut_RIS(dataPin, clockPin, 63);
      shiftOut_RIS(dataPin, clockPin, 14);
      shiftOut_RIS(dataPin, clockPin, 12);
      shiftOut_RIS(dataPin, clockPin, 62);
      shiftOut_RIS(dataPin, clockPin, 15);
      shiftOut_RIS(dataPin, clockPin, 224);
      shiftOut_RIS(dataPin, clockPin, 115);
      shiftOut_RIS(dataPin, clockPin, 227);
      shiftOut_RIS(dataPin, clockPin, 224);
      digitalWrite(latchPin1, HIGH);
      delay(t);
      digitalWrite(latchPin, LOW);
      shiftOut_RIS(dataPin, clockPin, 255);
      shiftOut_RIS(dataPin, clockPin, 192);
      shiftOut_RIS(dataPin, clockPin, 15);
      shiftOut_RIS(dataPin, clockPin, 131);
      shiftOut_RIS(dataPin, clockPin, 252);
      shiftOut_RIS(dataPin, clockPin, 0);
      shiftOut_RIS(dataPin, clockPin, 63);
      shiftOut_RIS(dataPin, clockPin, 240);
      shiftOut_RIS(dataPin, clockPin, 28);
      shiftOut_RIS(dataPin, clockPin, 15);
      shiftOut_RIS(dataPin, clockPin, 63);
      shiftOut_RIS(dataPin, clockPin, 192);
      shiftOut_RIS(dataPin, clockPin, 15);
      shiftOut_RIS(dataPin, clockPin, 252);
      shiftOut_RIS(dataPin, clockPin, 0);
      shiftOut_RIS(dataPin, clockPin, 255);
      shiftOut_RIS(dataPin, clockPin, 252);
      shiftOut_RIS(dataPin, clockPin, 15);
      shiftOut_RIS(dataPin, clockPin, 131);
      shiftOut_RIS(dataPin, clockPin, 248);
      shiftOut_RIS(dataPin, clockPin, 224);
      shiftOut_RIS(dataPin, clockPin, 63);
      shiftOut_RIS(dataPin, clockPin, 200);
      shiftOut_RIS(dataPin, clockPin, 3);
      shiftOut_RIS(dataPin, clockPin, 254);
      shiftOut_RIS(dataPin, clockPin, 240);
      shiftOut_RIS(dataPin, clockPin, 15);
      shiftOut_RIS(dataPin, clockPin, 200);
      shiftOut_RIS(dataPin, clockPin, 60);
      shiftOut_RIS(dataPin, clockPin, 31);
      shiftOut_RIS(dataPin, clockPin, 15);
      shiftOut_RIS(dataPin, clockPin, 240);
      shiftOut_RIS(dataPin, clockPin, 115);
      shiftOut_RIS(dataPin, clockPin, 227);
      shiftOut_RIS(dataPin, clockPin, 193);
      shiftOut_RIS(dataPin, clockPin, 248);
      shiftOut_RIS(dataPin, clockPin, 63);
      shiftOut_RIS(dataPin, clockPin, 14);
      shiftOut_RIS(dataPin, clockPin, 4);
      shiftOut_RIS(dataPin, clockPin, 248);
      shiftOut_RIS(dataPin, clockPin, 193);
      shiftOut_RIS(dataPin, clockPin, 199);
      shiftOut_RIS(dataPin, clockPin, 200);
      shiftOut_RIS(dataPin, clockPin, 60);
      shiftOut_RIS(dataPin, clockPin, 62);
      shiftOut_RIS(dataPin, clockPin, 7);
      shiftOut_RIS(dataPin, clockPin, 193);
      shiftOut_RIS(dataPin, clockPin, 240);
      shiftOut_RIS(dataPin, clockPin, 252);
      shiftOut_RIS(dataPin, clockPin, 15);
      digitalWrite(latchPin, HIGH);
      break;
    }

    case 50: // incident 0 deg,reflection 50 deg
    {
      digitalWrite(latchPin3, LOW);
      shiftOut_RIS(dataPin, clockPin, 240);
      shiftOut_RIS(dataPin, clockPin, 120);
      .
      .
      .
      shiftOut_RIS(dataPin, clockPin, 131);
      shiftOut_RIS(dataPin, clockPin, 3);
      digitalWrite(latchPin, HIGH);
      break;
    }

    default:
    {
      Serial.println("NO reflection angle,try ");
      break;
    }
    }
  }
}
*/