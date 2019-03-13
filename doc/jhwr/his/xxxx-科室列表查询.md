# <span style="color:red">无交易号</span>

## issues

<span style="color:red">

1. ~~未实现~~

</span>

### method

GetDepartmentTree

### in param

model

|name|type|required|description|
|:-|:-|:-:|:-|
|deptCode|string||科室编码|

sample

```json
{
    "deptCode": "2011"
}
```

### out param

model

|name|type|required|description|
|:-|:-|:-:|:-|
|ParentCode|string||一级科室编码|
|ParentName|string||科室|
|childrenList|array||二级科室列表|
|childrenList.DeptCode|string||二级科室编码|
|childrenList.DeptName|string||二级科室|
|childrenList.SimpleName|string|||

sample

```json
{
    "result": "success",
    "message": "",
    "data": [
        {
            "childrenList": [
                {
                    "DeptCode": "2241",
                    "DeptName": "中医科",
                    "SimpleName": "中医科"
                },
                {
                    "DeptCode": "2242",
                    "DeptName": "中医名医馆",
                    "SimpleName": "中医名医馆"
                },
                {
                    "DeptCode": "2243",
                    "DeptName": "中医疼痛门诊",
                    "SimpleName": "中医疼痛门诊"
                }
            ],
            "ParentCode": "2240",
            "ParentName": "中医"
        }
    ],
    "funName": 10,
    "outString": null
}
```