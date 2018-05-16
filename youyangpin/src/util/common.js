import cookie from 'js-cookie'
/**
 * 判断对象是否有值
 * @param  {object}  e 对象
 */
export const isEmptyObject = function(e) {
    var t
    for (t in e) {
        return !1
    }
    return !0
}
// export const setAuthCookie = () => {
//     let timestamp = Date.parse(new Date())
//     cookie.set('AuthTime', timestamp)
// }
//
// export const clearAuthCookie = () => {
//     cookie.remove('AuthTime')
// }
//
// export const isAuthTimeout = () => {
//     if (!cookie.get('AuthTime')) {
//         return true
//     }
//     let validityTime = 24 * 60 * 60 * 1000 // 24小时过期
//     let authTimestamp = cookie.get('AuthTime')
//     let currentTimestamp = Date.parse(new Date())
//     if (currentTimestamp < authTimestamp || (currentTimestamp - authTimestamp > validityTime)) {
//         cookie.remove('AuthTime')
//         return true
//     }
//     else {
//         return false
//     }
//
// }
//设置cookie
export const setCookie = (cname, cvalue, days = 1) => {
    var d = new Date();
    d.setTime(d.getTime() + (days * 24 * 60 * 60 * 1000));
    var expires = "expires=" + d.toUTCString();
    document.cookie = cname + "=" + cvalue + "; " + expires;
    // console.log(222,document.cookie);
}
//获取cookie
export const getCookie = (name) => {
    var getName = name + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') c = c.substring(1);
        if (c.indexOf(getName) != -1) return c.substring(name.length, c.length);
    }
    return "";
}
//清除cookie
export const clearCookie = (cname) => {
    this.setCookie(cname, "", -1);
    // console.log(11,document.cookie)
}
export const checkCookie = (cname) => {
    var user = this.getCookie(cname);
    if (user != "") {
        console.log("Welcome again " + user);
        return false
    } else {
        return true
        // if (user != "" && user != null) {
        //     this.setCookie(cname, user, 1);
        // }
    }
}