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