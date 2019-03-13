# 科室列表查询

## issues

<span style="color:red">
</span>

### route

api/v1/dept/tree

### in param

model

|name|type|required|description|
|:-|:-|:-:|:-|
|code|string||科室编码|

sample

```json
{
    "code": "2011"
}
```

### out param

model

|name|type|required|description|
|:-|:-|:-:|:-|
|pCode|string||一级科室编码|
|pName|string||科室|
|depts|array||二级科室列表|
|depts.code|string||二级科室编码|
|depts.name|string||二级科室|
|depts.simple|string|||

sample

```json
{
    "result": "success",
    "message": "",
    "data": [
        {
            "depts": [
                {
                    "code": "2241",
                    "name": "中医科",
                    "simple": "中医科"
                },
                {
                    "code": "2242",
                    "name": "中医名医馆",
                    "simple": "中医名医馆"
                },
                {
                    "code": "2243",
                    "name": "中医疼痛门诊",
                    "simple": "中医疼痛门诊"
                }
            ],
            "pCode": "2240",
            "pName": "中医"
        }
    ],
    "funName": 10,
    "outString": null
}
```