import ajax from '../fetch'

export default{
    /**
     * 登录
     */
    login(data, formJson = false, localLoading = 'login') {
        return ajax({
            url: '/user/login',
            method: 'post',
            localLoading,
            // formJson,
            body: data
        })
    },
    /**
     * 退出登录
     */
    logout(data, formJson = false, localLoading = 'logout') {
        return ajax({
            url: '/user/logout',
            method: 'delete',
            localLoading,
            formJson,
            body: data
        })
    },
    /**
     * 注册
     */
    register(data, localLoading = 'login') {
        return ajax({
            url: '/studiohost/register',
            method: 'post',
            localLoading,
            body: data
        })
    },
    /**
     * 获取图形验证码
     */
    getImgCode(isCommon = true, localLoading = 'getImgCode') {
        return ajax({
            url: '/common/getimgcode',
            localLoading
        })
    },
    /**
     * 短信验证码
     */
    getSmsCode(tel,isCommon = true, localLoading = 'getSmsCode') {
        return ajax({
            url: '/common/SendSms?telphone=' + tel,
            localLoading
        })
    },
    /**
     * 获取类型
     */
    getActivityTypes(localLoading = 'getActivityTypes') {
        return ajax({
            url: '/good/GetActivityTypes',
            localLoading
        })
    },
    getStatistics(localLoading = 'getStatistics') {
        return ajax({
            url: '/good/getStatistics',
            localLoading
        })
    },
    /**
     * 首页商品搜索
     */
    goodSearch(goodsName = '', verticalFieldCode = '', activityType = '', sales = '', lowDailyPrice = '', highDailyPrice = '', commissionRatio = '', pageIndex = 1, itemsPerPage = 10, sortField = '', sort = '', localLoading = 'goodsSearch') {
        return ajax({
            url: `/Good/Search?goodsName=${goodsName}&verticalFieldCode=${verticalFieldCode}&activityType=${activityType}&sales=${sales}&lowDailyPrice=${lowDailyPrice}&highDailyPrice=${highDailyPrice}&commissionRatio=${commissionRatio}&pageIndex=${pageIndex}&itemsPerPage=${itemsPerPage}&sortField=${sortField}&sort=${sort}`,
            localLoading
        })
    },
    /**
     * 商品详情
     */
    getGoodsDetail(goodsId, localLoading = 'getGoodsDetail') {
        return ajax({
            url: '/good/getdetail?goodsId=' + goodsId,
            localLoading
        })
    },
    /**
     * 我的订单
     */
    getPagedOrder(orderStatus, pageIndex = 1, itemsPerPage = 10, localLoading = 'getPagedOrder') {
        return ajax({
            url: `/Order/GetPagedOrder?orderStatus=${orderStatus}&pageIndex=${pageIndex}&itemsPerPage=${itemsPerPage}`,
            localLoading
        })
    },
    /**
     * 我的申请记录
     */
    getPagedRequest(checkStatus, pageIndex, itemsPerPage, localLoading = 'getPagedRequest') {
        return ajax({
            url: `/Order/GetPagedRequest?checkStatus=${checkStatus}&pageIndex=${pageIndex}&itemsPerPage=${itemsPerPage}`,
            localLoading
        })
    },
    /**
     * 提现记录
     */
    getMyRequests(localLoading = 'getMyRequests') {
        return ajax({
            url: '/Withdrawal/GetMyRequests',
            localLoading
        })
    },
    /**
     * 申请提现
     */
    requestMoney(amount, localLoading = 'requestMoney') {
        return ajax({
            url: '/RequestMoney?amount=' + amount,
            localLoading
        })
    },
    /**
     * 获取个人信息以及提现余额
     */
    getUserDetail(localLoading = 'getUserDetail') {
        return ajax({
            url: '/StudioHost/GetDetail',
            localLoading
        })
    },
    /**
     * 修改密码
     */
    changePassword(data, localLoading = 'changePassword') {
        return ajax({
            url: '/User/ChangePassword',
            method: 'post',
            localLoading,
            body: data
        })
    }
}