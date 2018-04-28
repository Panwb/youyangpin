import cookie from 'js-cookie'
/**
 * 判断对象是否有值
 * @param  {object}  e 对象
 */
export const isEmptyObject = function (e) {
    var t
    for (t in e) {
        return !1
    }
    return !0
}
export const setAuthCookie = () => {
    let timestamp = Date.parse(new Date())
    cookie.set('AuthTime', timestamp)
}

export const clearAuthCookie = () => {
    cookie.remove('AuthTime')
}

export const isAuthTimeout = () => {
    if (!cookie.get('AuthTime')) {
        return true
    }
    let validityTime = 24 * 60 * 60 * 1000 // 24小时过期
    let authTimestamp = cookie.get('AuthTime')
    let currentTimestamp = Date.parse(new Date())
    if (currentTimestamp < authTimestamp || (currentTimestamp - authTimestamp > validityTime)) {
        cookie.remove('AuthTime')
        return true
    }
    else {
        return false
    }

}