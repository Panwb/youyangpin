import {
    api as ajax
} from 'services';

export default {
    data() {
        const validatePass = (rule, value, callback) => {
            const passwordreg = /^[a-zA-Z0-9]{6,25}$/;
            if (value === '') {
                callback(new Error('请输入密码'));
            } else if (!passwordreg.test(value)) {
                callback(new Error('密码格式不正确'));
            } else {
                callback();
            }
        };
        const validatePass2 = (rule, value, callback) => {
            if (value === '') {
                callback(new Error('请再次输入密码'));
            } else if (value !== this.ruleForm2.password) {
                callback(new Error('两次输入密码不一致!'));
            } else {
                callback();
            }
        };
        const validateZbName = (rule, value, callback) => {
            console.log(value);
            if (value === '') {
                callback(new Error('请输入主播名称'));
            } else {
                callback();
            }
        };
        const validatemobilePhone = (rule, value, callback) => {
            const phonereg = /^[1][3,4,5,7,8][0-9]{9}$/;
            if (value === '') {
                callback(new Error('请输入手机号码'));
            } else if (!phonereg.test(value)) {
                callback(new Error('手机号码格式错误'));
            } else {
                callback();
            }
        };
        const validateyzCode = (rule, value, callback) => {
            if (value === '') {
                callback(new Error('请输入图形证码'));
            } else {
                callback();
            }
        };
        const validatemobileYzCode = (rule, value, callback) => {
            if (value === '') {
                callback(new Error('请输入6位数字短信验证码'));
            } else {
                callback();
            }
        };
        return {
            time: 90,
            sendMsgDisabled: false,
            dialogVisible: true,
            imgCode: '',
            isRead: false,
            ruleForm2: {
                telphone: '',
                password: '',
                checkPass: '',
                studioHostName: '',
                ImageIdentifyCode: '',
                SmsIdentifyCode: '',
                // pass: '',
                // checkPass: '',
                // zbName:'',
                // mobilePhone:'',
                // yzCode:'',
                // mobileYzCode:''
            },
            rules2: {
                password: [{
                    required: true,
                    validator: validatePass,
                    trigger: 'blur',
                }],
                checkPass: [{
                    required: true,
                    validator: validatePass2,
                    trigger: 'blur',
                }],
                studioHostName: [{
                    required: true,
                    validator: validateZbName,
                    trigger: 'blur',
                }],
                telphone: [{
                    required: true,
                    validator: validatemobilePhone,
                    trigger: 'blur',
                }],
                ImageIdentifyCode: [{
                    required: true,
                    validator: validateyzCode,
                    trigger: 'blur',
                }],
                SmsIdentifyCode: [{
                    required: true,
                    validator: validatemobileYzCode,
                    trigger: 'blur',
                }],
            },
        };
    },
    mounted() {
        //  this.getImgCode()
    },
    methods: {
        getImgCode() {
            ajax.getImgCode().then((result) => {
                this.imgCode = result;
            });
        },
        handleSelect(key, keyPath) {
            console.log(key, keyPath);
        },
        // 获取短信验证码
        getCode() {
            const phonereg = /^[1][3,4,5,7,8][0-9]{9}$/;
            if (this.ruleForm2.telphone === '' || !phonereg.test(this.ruleForm2.telphone)) {
                this.$message.error('请输入正确的手机号码');
                return;
            } else if (!this.sendMsgDisabled) {
                ajax.getByAccount(this.ruleForm2.telphone).then((result) => {
                    if (result) {
                        this.$message.warning('账号已存在');
                    } else {
                        ajax.getSmsCode(this.ruleForm2.telphone, 1).then(() => {
                            this.$message('验证码已发送你手机上');
                        });
                    }
                    this.sendMsgDisabled = true;
                    const that = this;
                    const interval = window.setInterval(function () {
                        if ((that.time--) <= 0) {
                            that.time = 90;
                            that.sendMsgDisabled = false;
                            window.clearInterval(interval);
                        }
                    }, 1000);
                });
            }
        },
        submitForm(formName) {
            this.$refs[formName].validate((valid) => {
                if (valid) {
                    ajax.register(this.ruleForm2).then((result) => {
                        this.$message.success('您已成功注册优样品账号，请及时登录主播个人中心，完善个人信息，账号信息需由客服人员审核通过后，方可在本平台申请拿样')
                        setTimeout(() => {
                            this.$router.push('/login');
                        }, 1000);
                    });
                    return true;
                }
                return false;
            });
        },
    },
};
