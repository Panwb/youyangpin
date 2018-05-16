import {
    api as ajax,
} from 'services';

export default {
    data() {
        const validateuserName = (rule, value, callback) => {
            if (!value) {
                callback(new Error('请输入主播名称'));
            } else {
                callback();
            }
        };
        const validateuserzhifuId = (rule, value, callback) => {
            if (!value) {
                callback(new Error('请输入支付宝账号'));
            } else {
                callback();
            }
        };
        const validateheight = (rule, value, callback) => {
            if (!value && value !== 0) {
                callback(new Error('请输入身高'));
            } else {
                callback();
            }
        };
        const validateweight = (rule, value, callback) => {
            if (!value && value !== 0) {
                callback(new Error('请输入体重'));
            } else {
                callback();
            }
        };
        const validateshoeSize = (rule, value, callback) => {
            if (!value && value !== 0) {
                callback(new Error('请输入鞋码'));
            } else {
                callback();
            }
        };
        const validateaddress = (rule, value, callback) => {
            if (!value) {
                callback(new Error('请输入收货地址'));
            } else {
                callback();
            }
        };
        const validatelinkName = (rule, value, callback) => {
            if (!value) {
                callback(new Error('请输入联系人姓名'));
            } else {
                callback();
            }
        };
        const validatelinkPhone = (rule, value, callback) => {
            if (!value) {
                callback(new Error('请输入联系人电话'));
            } else {
                callback();
            }
        };
        const validatewechatId = (rule, value, callback) => {
            if (!value) {
                callback(new Error('请输入微信号'));
            } else {
                callback();
            }
        };

        return {
            isShowCheck: true,
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
            asideIndex: '4',
            ruleForm: {
                CheckStatus: '',
                StudioHostName: '',
                AlipayAccount: '',
                Height: '',
                Weight: '',
                ShoeSize: '',
                ClothesSize: '',
                Address: '',
                LinkmanName: '',
                LinkmanPhone: '',
                TKName: '',
                WeChat: '',
                QQ: '',
                VerticalFieldCode: [],
                DailyBeginTime: '',
                DailyEndTime: '',
            },
            rules: {
                StudioHostName: [{
                    required: true,
                    validator: validateuserName,
                    trigger: 'blur',
                }],
                AlipayAccount: [{
                    required: true,
                    validator: validateuserzhifuId,
                    trigger: 'blur',
                }],
                Height: [{
                    required: true,
                    validator: validateheight,
                    trigger: 'blur',
                }],
                Weight: [{
                    required: true,
                    validator: validateweight,
                    trigger: 'blur',
                }],
                ShoeSize: [{
                    required: true,
                    validator: validateshoeSize,
                    trigger: 'blur',
                }],
                ClothesSize: [{
                    required: true,
                    message: '请选择尺码',
                    trigger: 'change',
                }],
                Address: [{
                    required: true,
                    validator: validateaddress,
                    trigger: 'blur',
                }],
                LinkmanName: [{
                    required: true,
                    validator: validatelinkName,
                    trigger: 'blur',
                }],
                LinkmanPhone: [{
                    required: true,
                    validator: validatelinkPhone,
                    trigger: 'blur',
                }],
                DailyBeginTime: [{
                    required: true,
                    message: '请选择时间',
                    trigger: 'change',
                }],
                DailyEndTime: [{
                    required: true,
                    message: '请选择时间',
                    trigger: 'change',
                }],
                WeChat: [{
                    required: true,
                    validator: validatewechatId,
                    trigger: 'blur',
                }],
            },
        };
    },
    created() {
        this.getUserDetail();
    },
    methods: {
        getUserDetail() {
            this.isShowCheck = false;
            ajax.getUserDetail().then((result) => {
                result.VerticalFieldCode = result.VerticalFieldCode ? result.VerticalFieldCode.split(',') : [];
                result.DailyBeginTime = result.DailyBeginTime && this.formatDate(result.DailyBeginTime, 'hm');
                result.DailyEndTime = result.DailyEndTime && this.formatDate(result.DailyEndTime, 'hm');
                this.ruleForm = result;
                this.isShowCheck = true;
            });
        },
        formatDate(date, type) {
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
        },
        handleSelect(key, keyPath) {
            this.$router.push(this.menus[key - 1].path);
        },
        submitForm(formName) {
            this.$refs[formName].validate((valid) => {
                if (valid) {
                    this.ruleForm.VerticalFieldCode = this.ruleForm.VerticalFieldCode ? this.ruleForm.VerticalFieldCode.join(',') : '';
                    ajax.updateStudioHost(this.ruleForm)
                        .then((result) => {
                            this.$message({
                                type: 'success',
                                message: '保存成功',
                            });
                            if (sessionStorage.getItem('goodid')) {
                                this.$router.go(-1);
                            } else {
                                this.getUserDetail();
                            }
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
    },
};