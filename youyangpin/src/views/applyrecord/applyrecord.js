import { api as ajax } from 'services'

export default {
    data () {
        return {
            menus: [
                {
                    title: '我的订单',
                    key: '1',
                    path: '/order'
                },
                {
                    title: '申请记录',
                    key: '2',
                    path: '/applyrecord'
                },
                {
                    title: '运费提现',
                    key: '3',
                    path: '/freight'
                },
                {
                    title: '个人信息',
                    key: '4',
                    path: '/user'
                },
                {
                    title: '修改密码',
                    key: '5',
                    path: '/modifypwd'
                }
            ],
            status: [
                {
                    name: '所有记录',
                    key: 'order1'
                },
                {
                    name: '待审核',
                    key: 'order2'
                }, 
                {
                    name: '审核通过',
                    key: 'order3'
                }, 
                {
                    name: '审核不通过',
                    key: 'order4'
                }
            ],
            asideIndex: '2',
            activeName: 'order1',
            currentStatu: '',
            pageIndex: 1,
            itemsPerPage: 10,
            total: 0,
            pageList: []
        }
    },
    created() {
        this.currentStatu = "";
        this.getPagedRequest()
    },
    methods: {
        handleSelect(key, keyPath) {
            this.$router.push(this.menus[key - 1]['path'])
        },
        handleClick(tab, event) {
            this.pageIndex = 1
            tab.label === '所有记录'?this.currentStatu = "" : this.currentStatu = tab.label;
            this.getPagedRequest()
        },
        getPagedRequest() {
            ajax.getPagedRequest(this.currentStatu, this.pageIndex, this.itemsPerPage).then((result) => {
                this.pageList = result.Orders
                this.total = result.RecordCount
            })
        },
        handleSizeChange(val) {
            console.log(`每页 ${val} 条`);
            this.itemsPerPage = val
            this.getPagedRequest()
        },
        handleCurrentChange(val) {
            console.log(`当前页: ${val}`);
            this.pageIndex = val
            this.getPagedRequest()
        },
        formatDate(date, type) {
             if (new Date(date) === 'Invalid Date') {
                 return date;
             } else if (date) {
                 date = new Date(date);
                 const y = date.getFullYear();
                 let m = date.getMonth() + 1;
                 m = m < 10 ? '0' + m : m;
                 let d = date.getDate();
                 d = d < 10 ? ('0' + d) : d;
                 let h = date.getHours();
                 h = h < 10 ? ('0' + h) : h;
                 let M = date.getMinutes();
                 M = M < 10 ? ('0' + M) : M;
                 let s = date.getSeconds();
                 s = s < 10 ? ('0' + s) : s;
                 switch (type) {
                     case "hms":
                         return y + '/' + m + '/' + d + " " + h + ':' + M + ':' + s;
                     case "timestamp":
                         return Date.parse(date);
                     case "ymdhM":
                         return y + '/' + m + '/' + d + " " + h + ':' + M;
                     case "md":
                         return m + '/' + d;
                     case "d":
                         return d;
                     case "hm":
                         return h + ':' + M;
                     default:
                         return y + '/' + m + '/' + d;
                 }
             }else {
                 return date
             }
         },
         cutString(str, len) {
            //length属性读出来的汉字长度为1
            if(!str || str.length <= len) {
                return str;
            }

            return str.substring(0, len) + '...';
        }
    }
}