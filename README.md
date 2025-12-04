# 🌐 XML Communication Demo

這是一個展示 **XML 通訊流程** 的示範專案。  
透過 HTTP Server / Client 架構，模擬接收 XML 指令、解析內容，並回傳 ACK XML。

---

## 🔧 專案功能

- ✔ 自動解析 XML attribute（如：`name`、`sn`...）
- ✔ Server 自動回覆 ACK XML
- ✔ Client 可讀取外部 XML 並送出
- ✔ 內建 XML Helper，快速解析 / 組 XML 回應

---

## 📂 專案結構

```text
xml-communication-demo/
 ├── src/
 │    ├── Program.cs             # 啟動 Server + Client
 │    ├── XmlCommandServer.cs    # XML Server：接收並解析 XML
 │    ├── XmlCommandClient.cs    # XML Client：送出 XML 指令
 │    ├── XmlHelper.cs           # XML 解析 & ACK 建構工具
 │    └── sample-command.xml     # 模擬用 XML
 ├── README.md
 ├── LICENSE
 └── .gitignore
```

---

📡 XML 指令示例

▶ sample-command.xml

```
<Command name="CheckIn" sn="ABC12345" />
```
▶ Server 解析結果
```
[SERVER] Parsed name=CheckIn, sn=ABC12345
```
▶ Server 回傳 ACK XML
```
<Ack status="OK" message="Command 'CheckIn' received." />
```

---

<h2>🚀 使用方式</h2>

專案啟動後會：

- 啟動 Server（接收 XML 指令）

- 啟動 Client（送出 sample-command.xml）

執行方式
```
dotnet run
```
---
<h2>🖥 Console 示範輸出</h2>

```
=== XML Communication Demo ===
[SERVER] XML Server started at http://localhost:5001/command
===== [SERVER] Received XML =====
<Command name="CheckIn" sn="ABC12345" />
=================================
===== [CLIENT] Response XML =====
<Ack status="OK" message="Command 'CheckIn' received." />
=================================
```

---
<h2>🧠 技術亮點</h2>

- 使用 XElement.Parse() 進行標準 XML 解析

- 使用 HttpListener 建立 HTTP Server（免額外套件）

- 可解析 XML attribute（name / sn 等）

- 完整 Server + Client 架構，可直接修改拓展

---

## 👤 作者

HungHsiang, Lin（林弘翔）

Software Engineer — C# / TCP/IP / XML Communication / Automation
