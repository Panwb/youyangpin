import { api as ajax } from 'services'

export default {
    data() {
        return {
            dialogVisible: false,
            menus: [{
                title: '我的订单',
                key: '1',
                path: '/order'
            }, {
                title: '申请记录',
                key: '2',
                path: '/applyrecord'
            }, {
                title: '运费提现',
                key: '3',
                path: '/freight'
            }, {
                title: '个人信息',
                key: '4',
                path: '/user'
            }, {
                title: '修改密码',
                key: '5',
                path: '/modifypwd'
            }],
            asideIndex: '3',
            freightData: {},
            tableData: []
        }
    },
    created() {
        this.getUserDetail();
        this.getMyRequests()
    },
    methods: {
        getUserDetail() {
            ajax.getUserDetail().then((result) => {
                this.freightData = result
            })
        },
        getMyRequests() {
            ajax.getMyRequests().then((result) => {
                this.tableData = result;
            })
        },
        requestMoney(formName) {
            this.$refs[formName].validate((valid) => {
                if (valid) {
                    ajax.requestMoney(this.freightData.AlipayAccount, this.freightData.AccountBalance)
                        .then((result) => {
                            this.$message({
                                type: 'success',
                                message: '提现成功'
                            });
                            this.dialogVisible = false;
                            this.getUserDetail();
                            this.getMyRequests();
                        })
                        .catch(error => {
                            this.$message({
                                type: "warning",
                                message: error
                            });
                        });
                } else {
                    console.log('error submit!!');
                    return false;
                }
            });
        },
        handleSelect(key, keyPath) {
            this.$router.push(this.menus[key - 1]['path'])
        },
        handleClick(tab, event) {
            console.log(tab, event);
        },
        handleClose(done) {
            this.$confirm('确认关闭？')
                .then(_ => {
                    done();
                })
                .catch(_ => {});
        },
        format(row, column, cellValue) {
            return this.formatDate(cellValue, 'hms');
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
                    default:
                        return y + '/' + m + '/' + d;
                }
            } else {
                return date
            }
        }
    }
}