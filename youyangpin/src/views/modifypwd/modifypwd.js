import { api as ajax } from 'services'

export default {
    data() {
        var validatesurepwd = (rule, value, callback) => {
            if (value === '') {
                callback(new Error('请再次输入密码'));
            } else if (value !== this.ruleForm.newpwd) {
                callback(new Error('两次输入密码不一致!'));
            } else {
                callback();
            }
        };
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
            asideIndex:'5',
            ruleForm: {
                prepwd:'',
                newpwd:'',
                surepwd:''
            },
            rules: {
                prepwd: [
                    { required: true, message: '请输入原密码', trigger: 'blur' }
                ],
                newpwd: [
                    { required: true, message: '请输入新密码', trigger: 'blur' }
                ],
                surepwd: [
                    { required: true, validator: validatesurepwd, trigger: 'blur' }
                ]
            } 
        }
    },
    methods: {
        handleSelect(key, keyPath) {
            this.$router.push(this.menus[key - 1]['path'])
        },
        submitForm(formName) {
            this.$refs[formName].validate((valid) => {
                if (valid) {
                    ajax.changePassword({
                        oldpassword: this.ruleForm.prepwd,
                        newpassword: this.ruleForm.newpwd
                    }).then((result) => {

                    })
                } else {
                    console.log('error submit!!');
                    return false;
                }
            });
        }
    }
}