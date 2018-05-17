import { api as ajax } from 'services';

export default {
    data() {
        return {
            dialogVisible: false,
            menus: [{
                title: '我的订单',
                key: '1',
                path: '/order',
            }, {
                title: '申请记录',
                key: '2',
                path: '/applyrecord',
            }, {
                title: '运费提现',
                key: '3',
                path: '/freight',
            }, {
                title: '个人信息',
                key: '4',
                path: '/user',
            }, {
                title: '修改密码',
                key: '5',
                path: '/modifypwd',
            }],
            asideIndex: '3',
            freightData: {},
            tableData: [],
        };
    },
    created() {
        this.getUserDetail();
        this.getMyRequests();
    },
    methods: {
        getUserDetail() {
            ajax.getUserDetail().then((result) => {
                this.freightData = result;
            });
        },
        getMyRequests() {
            ajax.getMyRequests().then((result) => {
                this.tableData = result;
            });
        },
        requestMoney(formName) {
            this.$refs[formName].validate((valid) => {
                if (valid) {
                    ajax.requestMoney(this.freightData.AlipayAccount, this.freightData.AccountBalance)
                        .then((result) => {
                            this.$message({
                                type: 'success',
                                message: '提现成功',
                            });
                            this.dialogVisible = false;
                            this.getUserDetail();
                            this.getMyRequests();
                        })
                        .catch(error => {
                            this.$message({
                                type: 'warning',
                                message: error,
                            });
                        });
                    return true;
                }
                console.log('error submit!!');
                return false;
            });
        },
        handleSelect(key, keyPath) {
            this.$router.push(this.menus[key - 1].path);
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
        applyClick() {
            if (this.freightData.AccountBalance < 100 || !this.freightData.AlipayAccount) {
                this.dialogVisible = false;
            } else {
                this.dialogVisible = true;
            }
        },
        format(row, column, cellValue) {
            return this.formatDate(cellValue, 'hms');
        },        
        formatDate(date, type) {
            return this.util.formatDate(date, type);
        },
    },
};