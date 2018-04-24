import { api as ajax } from 'services'

export default {
    data() {
        var validatemobilePhone = (rule, value, callback) => {
            var phonereg=/^[1][3,4,5,7,8][0-9]{9}$/;  
            if (value === '') {
              callback(new Error('请输入手机号码'));
            }else if(!phonereg.test(value)){
              callback(new Error('手机号码格式错误'));
            }else {
              callback();
            }
        };
        var validateyzCode = (rule, value, callback) => {
            if (value === '') {
              callback(new Error('请输入图形证码'));
            }else {
              callback();
            }
        };
        var validatemobileYzCode = (rule, value, callback) => {
            if (value === '') {
              callback(new Error('请输入6位数字短信验证码'));
            }else {
              callback();
            }
        };
        var validatePass = (rule, value, callback) => {
            var passwordreg=/^[a-zA-Z0-9]{6,10}$/;  
            if (value === '') {
              callback(new Error('请输入密码'));
            } else if(!passwordreg.test(value)){
              callback(new Error('密码格式不正确'));
            }else {
              callback();
            }
        };
        var validatePass2 = (rule, value, callback) => {
            if (value === '') {
              callback(new Error('请再次输入密码'));
            } else if (value !== this.ruleForm3.pass) {
              callback(new Error('两次输入密码不一致!'));
            } else {
              callback();
            }
        };
        return {
            imgCode: '',
            active: 1,
            ruleForm1: {
                mobilePhone:'',
                yzCode:''
            },
            ruleForm2: {
                mobileYzCode:''
            },
            ruleForm3: {
                pass: '',
                checkPass: ''
            },
            rules1: {
                yzCode:[
                    { required: true, validator: validateyzCode, trigger: 'blur' }
                ],
                mobilePhone:[
                    { required: true, validator: validatemobilePhone, trigger: 'blur' }
                ]
            },
            rules2: {
                mobileYzCode:[
                    { required: true, validator: validatemobileYzCode, trigger: 'blur' }
                ]
            },
            rules3: {
                pass: [
                    { required: true, validator: validatePass, trigger: 'blur' }
                ],
                checkPass: [
                    { required: true, validator: validatePass2, trigger: 'blur' }
                ]
            }
        }
    },
    created() {
        this.getImgCode()
    },
    methods: {
        getImgCode() {
            ajax.getImgCode().then((result) => {
               this.imgCode = result
            })
        },
        getCode() {
            ajax.getSmsCode(this.ruleForm1.mobilePhone).then((result) => {
                this.$message('验证码已发送你手机上');
               // this.ruleForm2.mobileYzCode = result
            })
        },
        handleSelect(key, keyPath) {
            console.log(key, keyPath);
        },
        handleClick(tab, event) {
            console.log(tab, event);
        },
        submitForm(formName) {
            let that = this;
            this.$refs[formName].validate((valid) => {
                if (valid) {
                    that.active++
                    if (that.active >= 4) {
                        that.active = 4
                    }
                } else {
                    console.log('error submit!!');
                    return false;
                }
            });
        }
    }
}