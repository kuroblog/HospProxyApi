# 挂号列表查询

## issues

<span style="color:red">
</span>

### route

api/v1/register/query

### in param

model

|name|type|required|description|
|:-|:-|:-:|:-|
|cardNo|string|y|10位就诊卡号|

sample

```json
{
    "cardNo": "0000090147"
}
```

### out param

model

|name|type|required|description|
|:-|:-|:-:|:-|
|state|string||支付状态<br>1 已支付<br>2 未支付<br>3 已取消<br>4 已失效|
|deptName|string||科室|
|regType|string||预约类型<br>1 专家号<br>2 普通号|
|regDate|string||就诊日期|
|doctName|string||医生|
|doctTitle|string||医生职称|
|cost|string||总费用|
|cardNo|string||10位就诊卡号|
|name|string||姓名|
|operDate|string||提交时间|
|seeNo|string||看诊序号|
|clinicNo|string||就诊唯一号|

sample

```json
{
    "result": "success",
    "message": "",
    "data": [
        {
            "state": "1",
            "deptName": "",
            "regType": "1",
            "regDate": "2018/11/28 11:21:24",
            "tdocName": "陈平",
            "doctTitle": "副主任医师",
            "cost": 14,
            "cardNo": "0000086027",
            "name": "胡天水",
            "operDate": "2018/11/28 9:45:50",
            "seeNo": "7",
            "clinicNo": "197331"
        }
    ],
    "funName": 10,
    "outString": null
}
```