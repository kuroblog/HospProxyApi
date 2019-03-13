# issues & logs

## issues

<span style="color:red">

1. ~~需要和 HIS 重新定义 operCode~~
1. 数据字典查询中的支付类别，返回的数据里有重复数据
1. ~~挂号和预约产生的缴费数据，还不能在待缴费列表里查询到~~
1. ~~挂号列表查询返回的数据，缺少已经取消的挂号记录~~
1. ~~科室列表树形查询还没有实现~~
1. ~~预约功能还没有实现~~~
1. ~~预约列表查询还没有实现~~
1. ~~预约取号还没有实现~~
1. ~~预约取消还没有实现~~
1. ~~挂号取消时，需要把未支付的挂号记录从待缴费列表里删除掉~~
1. 挂号取消时，似乎没有把号源还回去？
1. ~~挂号列表查询，返回的数据似乎有重复记录？~~
1. 用于部署生产环境的 Linux 虚拟机版本不正确
1. HIS 系统允许在一天内，挂多次号但只收一次挂号费用，且可以看所有的可挂号科室

</span>

## logs

* his service is web-service
* his database(oracle)

    * test: unknown
    * prod: unknown

* service-url

    * test: <http://192.168.0.186:8081/AppServiceCommon.asmx>
    * prod: <http://192.168.0.186:8085/AppServiceCommon.asmx>

* vpn

    * 公网登录
        * url: <https://122.226.57.34:8443>
        * uid: admin
        * pwd: iceflow
    * 内网登录
        * url: <http://192.168.18.171:8080>
        * uid: admin
        * pwd: iceflow
    * 客户端: ICEFLOW VPN Client
    * 版本: 4.1.16
    * VPN 支持: QQ 395624147
    * VPN 登录
        * url: <http://122.226.57.34:8443>
        * uid: xuhui
        * pwd: 123456
    * 测试环境
        * host: 192.168.0.45
        * uid: administrator
        * pwd: Actech@123
    * 生产环境
        * host: 192.168.0.113
        * uid: root
        * pwd: Actech@123
        * <span style="color:red">radhat 的系统需要是正版订阅的才可以使用</span>
            * subId: 8b9943c5-0e35-42f9-b287-774df65856e7
            * subName: zhaoyuqi
            * subPwd: !Qaz2wsx