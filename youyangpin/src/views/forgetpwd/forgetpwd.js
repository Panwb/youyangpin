import { api as ajax } from 'services';

export default {
    data() {
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
            } else if (value !== this.ruleForm3.newPassword) {
                callback(new Error('两次输入密码不一致!'));
            } else {
                callback();
            }
        };
        return {
            time: 90,
            sendMsgDisabled: false,
            imgCode: '',
            active: 1,
            ruleForm1: {
                telphone: '',
                imageIdentifyCode: '',
            },
            ruleForm2: {
                smsIdentifyCode: '',
            },
            ruleForm3: {
                newPassword: '',
                checkPass: '',
            },
            rules1: {
                imageIdentifyCode: [{
                    required: true,
                    validator: validateyzCode,
                    trigger: 'blur',
                }],
                telphone: [{
                    required: true,
                    validator: validatemobilePhone,
                    trigger: 'blur',
                }],
            },
            rules2: {
                smsIdentifyCode: [{
                    required: true,
                    validator: validatemobileYzCode,
                    trigger: 'blur',
                }],
            },
            rules3: {
                newPassword: [{
                    required: true,
                    validator: validatePass,
                    trigger: 'blur',
                }],
                checkPass: [{
                    required: true,
                    validator: validatePass2,
                    trigger: 'blur',
                }],
            },
        };
    },
    created() {
        this.getImgCode();
    },
    methods: {
        getImgCode() {
            ajax.getImgCode().then((result) => {
                this.imgCode = result;
            });
        },
        getCode() {
            const phonereg = /^[1][3,4,5,7,8][0-9]{9}$/;
            if (this.ruleForm1.telphone === '' || !phonereg.test(this.ruleForm1.telphone)) {
                this.$message.error('请输入正确的手机号码');
                return;
            } else if (!this.sendMsgDisabled) {
                ajax.getSmsCode(this.ruleForm1.telphone, 2).then((result) => {
                    this.$message('验证码已发送你手机上');
                });
            }
            this.sendMsgDisabled = true;
            const that = this;
            const interval = window.setInterval(function() {
                if ((that.time--) <= 0) {
                    that.time = 90;
                    that.sendMsgDisabled = false;
                    window.clearInterval(interval);
                }
            }, 1000);
        },
        handleSelect(key, keyPath) {
            console.log(key, keyPath);
        },
        handleClick(tab, event) {
            console.log(tab, event);
        },
        submitForm(formName, formValue) {
            const that = this;
            this.$refs[formName].validate((valid) => {
                if (valid) {
                    switch (formName) {
                        case 'ruleForm1':
                            ajax.retrievePassword(formValue)
                                .then((result) => {
                                    that.active = 2;
                                })
                                .catch(error => {
                                    that.active = 1;
                                    this.$message({
                                        type: 'warning',
                                        message: error,
                                    });
                                });
                            break;
                        case 'ruleForm2':
                            ajax.validateSmsIdentifyCode(formValue, 'ForgetPwdSmsIdentifyCode')
                                .then((result) => {
                                    that.active = 3;
                                })
                                .catch(error => {
                                    that.active = 2;
                                    this.$message({
                                        type: 'warning',
                                        message: error,
                                    });
                                });
                            break;
                        case 'ruleForm3':
                            ajax.resetPassword(formValue)
                                .then((result) => {
                                    that.active = 4;
                                })
                                .catch(error => {
                                    that.active = 3;
                                    this.$message({
                                        type: 'warning',
                                        message: error,
                                    });
                                });
                            break;
                    }
                    if (that.active >= 4) {
                        that.active = 4;
                    }
                    return true;
                }
                console.log('error submit!!');
                return false;
            });
        },
    },
};