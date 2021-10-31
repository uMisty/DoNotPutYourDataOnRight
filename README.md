# Don't put your data on right

将Excel中的表单转换为结构化数据  

例如  
Input 1:
<table clas="table table-bordered table-striped table-condensed">
    <tr>
        <td>姓名</td>
        <td>张三</td>
        <td>年龄</td>
        <td>18</td>
    <tr>    
    <tr>
        <td>性别</td>
        <td>男</td>
        <td>描述</td>
        <td>一个快乐男孩</td>
    <tr>
</table>

Input 2:
<table clas="table table-bordered table-striped table-condensed">
    <tr>
        <td>姓名</td>
        <td>小红</td>
        <td>年龄</td>
        <td>16</td>
    <tr>    
    <tr>
        <td>性别</td>
        <td>女</td>
        <td>描述</td>
        <td>可能这个名字比较适合表明他是个女孩</td>
    <tr>
</table>

Output(Json):
```json
[
  {
    "姓名":"张三",
    "年龄":"18",
    "性别":"男",
    "描述":"一个快乐男孩"
  },
  {
    "姓名":"小红",
    "年龄":"16",
    "性别":"女",
    "描述":"可能这个名字比较适合表明他是个女孩"
  }
]
```

Output(csv/excel):
|姓名|年龄|性别|描述|
|--|--|--|--|
|张三|18|男|一个快乐男孩|
|小红|16|女|可能这个名字比较适合表明他是个女孩|
