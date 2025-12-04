XML Communication Demo

這是一個展示 XML 通訊流程 的專案。
透過 HTTP Server / Client 架構，模擬如何接收 XML 指令、解析內容、並回傳回應（ACK XML）。

🔧 專案功能

✔ 自動解析 XML attribute（如：name、sn…）

✔ Server 自動回覆 ACK XML

✔ Client 可讀取外部 XML 檔案並送出

📂 專案結構
xml-communication-demo/
 ├── src/
 │    ├── Program.cs             # 啟動 Server + Client
 │    ├── XmlCommandServer.cs    # XML Server：接收並解析 XML
 │    ├── XmlCommandClient.cs    # XML Client：上傳 XML 指令
 │    ├── XmlHelper.cs           # XML 解析 & ACK 建構工具
 │    └── sample-command.xml     # 模擬用的 XML內容
 ├── README.md
 ├── LICENSE
 └── .gitignore

📡 XML 封包示例
▶ sample-command.xml
<Command name="CheckIn" sn="ABC12345" />

▶ Server 解析結果
[SERVER] Parsed name=CheckIn, sn=ABC12345

▶ Server 回傳 ACK XML
<Ack status="OK" message="Command 'CheckIn' received." />

🚀 使用方式

專案啟動後會同時開啟：

一個 XML Server（接收指令）

一個 XML Client（送出指令）

執行：
dotnet run

Console 顯示示例：
=== XML Communication Demo ===
[SERVER] XML Server started at http://localhost:5001/command
===== [SERVER] Received XML =====
<Command name="CheckIn" sn="ABC12345" />
=================================
===== [CLIENT] Response XML =====
<Ack status="OK" message="Command 'CheckIn' received." />
=================================

🧠 技術亮點

XElement.Parse → 標準 XML 解析方式

HttpListener → 內建即可啟動 HTTP Server


👤 作者

HungHsiang, Lin（林弘翔）
Software Engineer — C# / TCP/IP / XML Communication / Automation
