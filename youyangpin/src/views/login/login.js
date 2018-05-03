import { api as ajax } from 'services'

import { mapActions } from 'vuex'

export default {
    data() {
        var validatePass = (rule, value, callback) => {
            var passwordreg=/^[a-zA-Z0-9]{6,25}$/;
            if (value === '') {
                callback(new Error('请输入密码'));
            } else if(!passwordreg.test(value)){
                callback(new Error('密码格式不正确'));
            }else {
                callback();
            }
        };
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
                callback(new Error('请输入验证码'));
            }else {
                callback();
            }
        };
        return {
            imgCode: '',
            ruleForm2: {
                accountName: '',
                password:'',
                identifyCode:'',
            },
            rules2: {
                password: [
                    { required: true, validator: validatePass, trigger: 'blur' }
                ],
                accountName:[
                    { required: true, validator: validatemobilePhone, trigger: 'blur' }
                ],
                identifyCode:[
                    { required: true, validator: validateyzCode, trigger: 'blur' }
                ]
            }
        };
    },
    created() {
        this.getImgCode()
    },
    methods: {
        ...mapActions([
            'setAccount'
        ]),
        getImgCode() {
            ajax.getImgCode().then((result) => {
               this.imgCode = result
            })
        },
        submitForm(formName) {
            this.$refs[formName].validate((valid) => {
                if (valid) {
                    ajax.login(this.ruleForm2).then((result) => {
                        // 登录成功
                        result = JSON.stringify(result);
                        this.util.setCookie('user',result,1);
                        // localStorage.setItem('user',result);
                        const redirect = decodeURIComponent(this.$route.query.redirect || '/index');
                        this.$router.push(redirect);
                    }).catch(error => {
                        this.getImgCode()
                    })
                } else {
                    console.log('error submit!!');
                    return false;
                }
            });
        }
    }
}