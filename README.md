# TWjpRunner
一個不用修改系統非Unicode語言，卻又可以幫忙轉語系的小工具

### **使用環境**
* [Firefox](https://www.mozilla.org/zh-TW/firefox/new/)
* [Locale.Emulator最新版](https://xupefei.github.io/Locale-Emulator/)
* [.Net Core Desktop Runtime](https://dotnet.microsoft.com/download/dotnet-core/3.1)(必須安裝, 推薦3.1.10以上版本)

### **下載**
* [TWjpRunner 1.0.1](https://github.com/hawiliu/TWjpRunner/blob/master/Upload/TWjpRunner.zip?raw=true)

### **使用教學**
1. 下載TWjpRunner並放到任意位置(建議路徑內不要有中文名稱)
2. 修改TWjpRunner資料夾內的appsetting.json的LEProcPath  
依照Locale.Emulator放的位置自行填入LEProc.exe的路徑  
~~理論上NgmPath不需要修改~~  
因應20220622遊戲版本更新, 會需要將NgmPath修改為  
    `"C:\\ProgramData\\NexonJP\\NGM\\NGM64.exe"`
![image](https://raw.githubusercontent.com/hawiliu/TWjpRunner/master/Upload/Image/appsetting.PNG)
3. 開啟Firefox的選項，往下拉找到應用程式的ngmj選項，並修改成使用TWjpRunner.exe執行  
![image](https://raw.githubusercontent.com/hawiliu/TWjpRunner/master/Upload/Image/ngmj.PNG)
4. 正常在官網登錄並點GameStart
5. 如果跳出是否允許執行請按是  
![image](https://raw.githubusercontent.com/hawiliu/TWjpRunner/master/Upload/Image/Yes.PNG)
6. 如果是第一次執行可能會跳出LEGUI設定畫面，可參考下圖設定即可  
![image](https://raw.githubusercontent.com/hawiliu/TWjpRunner/master/Upload/Image/LEGUI.PNG)
7. 開始玩遊戲囉~

### **疑難排解**
Q.遊戲出現20015錯誤
>A.確認Talesweaver.exe的LEGUI參數欄位是不是空的, 或是firefox網頁重新整理確認是否需要重登
>![image](https://raw.githubusercontent.com/hawiliu/TWjpRunner/master/Upload/Image/Setting.png)
>![image](https://raw.githubusercontent.com/hawiliu/TWjpRunner/master/Upload/Image/Check.png)

Q.使用之前的版本, 啟動時只有閃過黑色視窗卻沒有啟動遊戲
>A1.確認appsetting.json內設定是否正確  
>A2.確認是否有安裝.Net Core Desktop Runtime 3.1.10以上的版本
>![image](https://raw.githubusercontent.com/hawiliu/TWjpRunner/master/Upload/Image/aspnetcore.PNG)

Q.系統為Win11, 啟動卡在黑色視窗
>A.確認切換語系的程式為v2.5.0.1以上

**聲明**  
如果不當使用造成任何問題，後果請自行負責。
