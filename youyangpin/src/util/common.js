import cookie from 'js-cookie';
/**
 * 判断对象是否有值
 * @param  {object}  e 对象
 */
export const isEmptyObject = function (e) {
    var t;
    for (t in e) {
        return !1;
    }
    return !0;
};
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
// 设置cookie
export const setCookie = (cname, cvalue, days = 1) => {
    let d = new Date();
    d.setTime(d.getTime() + (days * 24 * 60 * 60 * 1000));
    let expires = 'expires=' + d.toUTCString();
    document.cookie = cname + '=' + cvalue + '; ' + expires;
    // console.log(222,document.cookie);
};
// 获取cookie
export const getCookie = (name) => {
    let getName = name + '=';
    let ca = document.cookie.split(';');
    for (let i = 0; i < ca.length; i++) {
        let c = ca[i];
        while (c.charAt(0) === ' ') c = c.substring(1);
        if (c.indexOf(getName) !== -1) return c.substring(name.length, c.length);
    }
    return '';
};
// 清除cookie
export const clearCookie = (cname) => {
    this.setCookie(cname, '', -1);
    // console.log(11,document.cookie)
};
export const checkCookie = (cname) => {
    var user = this.getCookie(cname);
    if (user !== '') {
        console.log('Welcome again ' + user);
        return false;
    }
    return true;
};

export const formatDate = (date, type) => {
    if (new Date(date) === 'Invalid Date') {
        return date;
    } else if (date) {
        const datetime = new Date(date);
        const y = datetime.getFullYear();
        let m = datetime.getMonth() + 1;
        m = m < 10 ? `0${m}` : m;
        let d = datetime.getDate();
        d = d < 10 ? `0${d}` : d;
        let h = datetime.getHours();
        h = h < 10 ? `0${h}` : h;
        let M = datetime.getMinutes();
        M = M < 10 ? `0${M}` : M;
        let s = datetime.getSeconds();
        s = s < 10 ? `0${s}` : s;
        switch (type) {
            case 'hms':
                return `${y}/${m}/${d} ${h}:${M}:${s}`;
            case 'timestamp':
                return Date.parse(datetime);
            case 'ymdhM':
                return `${y}/${m}/${d} ${h}:${M}`;
            case 'md':
                return `${m}/${d}`;
            case 'd':
                return d;
            case 'hm':
                return `${h}:${M}`;
            default:
                return `${y}/${m}/${d}`;
        }
    } else {
        return date;
    }
};

export const cutString = (str, len) => {
    //  length属性读出来的汉字长度为1
    if (!str || str.length <= len) {
        return str;
    }

    return `${str.substring(0, len)}...`;
};