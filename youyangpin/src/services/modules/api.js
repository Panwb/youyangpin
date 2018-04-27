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
    getStatistics(searchForm,localLoading = 'getStatistics') {
        return ajax({
            url: `/good/getStatistics?activityType=${searchForm.activityType}`,
            localLoading
        })
    },
    /**
     * 首页商品搜索
     */
    goodSearch(searchForm,localLoading = 'goodsSearch') {
        return ajax({
            url: `/Good/Search?goodsName=${searchForm.goodsName}&verticalFieldCode=${searchForm.verticalFieldCode}&activityType=${searchForm.activityType}&lowSales=${searchForm.lowSales}&highSales=${searchForm.highSales}&lowDailyPrice=${searchForm.lowDailyPrice}&highDailyPrice=${searchForm.highDailyPrice}&lowCommissionRatio=${searchForm.lowCommissionRatio}&highCommissionRatio=${searchForm.highCommissionRatio}&pageIndex=${searchForm.pageIndex}&itemsPerPage=${searchForm.itemsPerPage}&sortField=${searchForm.sortField}&sort=${searchForm.sort}`,
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
    requestApplication(data, localLoading = 'requestApplication') {
        return ajax({
            url: '/Order/Add',
            method: 'post',
            localLoading,
            body: data
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
     * 保存个人信息
     */
    updateStudioHost(data, localLoading = 'updateStudioHost') {
        return ajax({
            url: '/StudioHost/Update',
            method: 'post',
            localLoading,
            body: data
        })
    },
    /**
     * 修改密码
     */
    changePassword(data,localLoading = 'changePassword') {
        return ajax({
            url: `/User/ChangePassword?oldpassword=${data.oldpassword}&newpassword=${data.newpassword}`,
            method: 'put',
            localLoading
        })
    },
    /**
     * 忘记密码
     */
    retrievePassword(data,localLoading = 'retrievePassword') {
        return ajax({
            url: `/User/RetrievePassword?telphone=${data.telphone}&imageIdentifyCode=${data.imageIdentifyCode}`,
            localLoading
        })
    },
    validateSmsIdentifyCode(smsIdentifyCode, localLoading = 'validateSmsIdentifyCode') {
        return ajax({
            url: `/Common/ValidateSmsIdentifyCode?smsIdentifyCode=${smsIdentifyCode}`,
            localLoading
        })
    },
    resetPassword(newPassword, localLoading = 'resetPassword') {
        return ajax({
            url: `/User/ResetPassword?newPassword=${newPassword}`,
            method: 'put',
            localLoading
        })
    },

}