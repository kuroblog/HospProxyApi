# 预约列表查询

## issues

<span style="color:red">
</span>

### route

api/v1/pre/list

### in param

model

|name|type|required|description|
|:-|:-|:-:|:-|
|cardNo|string|y|10位就诊卡号|

sample

```json
{
    "cardNo": "0000086027"
}
```

### out param

model

|name|type|required|description|
|:-|:-|:-:|:-|
|state|string||预约状态<br>0 已取消<br>1 正常<br>2 预约转挂号|
|deptName|string||科室|
|preRegType|string||预约类型<br>ZJ 专家号<br>PT 普通号|
|preReggDate|string||预约日期|
|doctName|string||医生|
|doctTitle|string||医生职称|
|cost|string||总费用|
|cardNo|string||10位就诊卡号|
|name|string||姓名|
|operDate|string||提交时间|
|seeNo|string||看诊序号|
|clinicNo|string||就诊唯一号|
|preNo|string||预约唯一号|

sample

```json
{
    "result": "success",
    "message": "",
    "data": [
        {
            "state": "1",
            "deptName": "内分泌科门诊",
            "preRegType": "ZJ",
            "preRegDate": "2018/12/10 7:00:00",
            "doctName": "陈平",
            "doctTitle": "副主任医师",
            "cost": "14",
            "cardNo": "0000086027",
            "name": "胡天水",
            "operDate": "2018/12/4 17:11:28",
            "seeNo": "1",
            "clinicNo": "203275",
            "bookingNo": "26"
        }
    ],
    "funName": 10,
    "outString": null
}
```