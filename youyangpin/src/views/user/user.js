import { api as ajax } from 'services'

export default {
    data() {
        var validateuserName = (rule, value, callback) => {
            if (value === '') {
                callback(new Error('请输入主播名称'));
            }else {
                callback();
            }
        };
        var validateuserzhifuId= (rule, value, callback) => {
            if (value === '') {
                callback(new Error('请输入支付宝账号'));
            }else {
                callback();
            }
        };
        var validateheight= (rule, value, callback) => {
            if (value === '') {
                callback(new Error('请输入身高'));
            }else {
                callback();
            }
        };
        var validateweight= (rule, value, callback) => {
            if (value === '') {
                callback(new Error('请输入体重'));
            }else {
                callback();
            }
        };
        var validateshoeSize= (rule, value, callback) => {
            if (value === '') {
                callback(new Error('请输入鞋码'));
            }else {
                callback();
            }
        };
        var validateaddress= (rule, value, callback) => {
            if (value === '') {
                callback(new Error('请输入收货地址'));
            }else {
                callback();
            }
        };
        var validatelinkName= (rule, value, callback) => {
            if (value === '') {
                callback(new Error('请输入联系人姓名'));
            }else {
                callback();
            }
        };
        var validatelinkPhone= (rule, value, callback) => {
            if (value === '') {
                callback(new Error('请输入联系人电话'));
            }else {
                callback();
            }
        };
        var validatewechatId= (rule, value, callback) => {
            if (value === '') {
                callback(new Error('请输入微信号'));
            }else {
                callback();
            }
        };
        var validatetkName= (rule, value, callback) => {
            if (value === '') {
                callback(new Error('请输入淘客名称'));
            }else {
                callback();
            }
        };
        var validateqqId= (rule, value, callback) => {
            var qqreg=/[1-9]\\d{4,14}/;  
            if (!qqreg.test(value)) {
                callback(new Error('qq号码格式不正确'));
            }else {
                callback();
            }
        };

        return {
            isShowCheck: true,
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
            asideIndex:'4',
            ruleForm: {
                // StudioHostName: '',
                // AlipayAccount: '',
                // Height: '',
                // Weight: '',
                // ShoeSize: '', // 鞋码
                // ClothesSize: '', // 尺码
                // Address: '',
                // LinkmanName: '',
                // LinkmanPhone: '',
                // TKName: '',
                // WeChat: '',
                // QQ: '',
                // DailyBeginTime: '',
                CheckStatus: '',
                StudioHostName: '',
                AlipayAccount:'',
                Height:'',
                Weight:'',
                ShoeSize:'',
                ClothesSize:'',
                Address:'',
                LinkmanName:'',
                LinkmanPhone:'',
                TKName:'',
                WeChat: '',
                QQ:'',
                VerticalFieldCode: [],
                DailyBeginTime: '',
                DailyEndTime: ''
            },
            rules: {
                StudioHostName: [
                    { required: true, validator: validateuserName, trigger: 'blur' }
                 ],
                AlipayAccount: [
                    { required: true, validator: validateuserzhifuId, trigger: 'blur' }
                ],
                Height: [
                    { required: true, validator: validateheight, trigger: 'blur' }
                ],
                Weight: [
                    { required: true, validator: validateweight, trigger: 'blur' }
                ],
                ShoeSize: [
                    { required: true, validator: validateshoeSize, trigger: 'blur' }
                ],
                ClothesSize: [
                    { required: true, message: '请选择尺码', trigger: 'change' }
                ],
                Address: [
                    { required: true, validator: validateaddress, trigger: 'blur' }
                ],
                LinkmanName: [
                    { required: true, validator: validatelinkName, trigger: 'blur' }
                ],
                LinkmanPhone: [
                    { required: true, validator: validatelinkPhone, trigger: 'blur' }
                ],
                DailyBeginTime: [
                    { required: true, message: '请选择时间', trigger: 'change' }
                ],
                DailyEndTime: [
                    { required: true, message: '请选择时间', trigger: 'change' }
                ],
                WeChat: [
                    { required: true, validator: validatewechatId, trigger: 'blur' }
                ]
            }
        }
    },
    created() {
        this.getUserDetail()
    },
     methods: {
        getUserDetail() {
            this.isShowCheck = false;
            ajax.getUserDetail().then((result) => {
                result.VerticalFieldCode = result.VerticalFieldCode && result.VerticalFieldCode.split(',');
                result.DailyBeginTime = result.DailyBeginTime && this.formatDate(result.DailyBeginTime,'hm');
                result.DailyEndTime = result.DailyEndTime && this.formatDate(result.DailyEndTime,'hm');
                this.ruleForm = result;
                this.isShowCheck = true;
            })
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
        handleSelect(key, keyPath) {
            this.$router.push(this.menus[key - 1]['path'])
        },
        submitForm(formName) {
            this.$refs[formName].validate((valid) => {
                if (valid) {
                    this.ruleForm.VerticalFieldCode = this.ruleForm.VerticalFieldCode.join();
                    ajax.updateStudioHost(this.ruleForm)
                        .then((result) => {
                            this.$message({type:"success",message:"保存成功"});
                            if(sessionStorage.getItem('goodid')) {
                                this.$router.go(-1);
                            }else {
                                this.getUserDetail();
                            }
                        })
                        .catch(error => {
                            this.$message({type:"warning",message: error});
                        });
                } else {
                    console.log('error submit!!');
                    return false;
                }
            });
        }
    }
}