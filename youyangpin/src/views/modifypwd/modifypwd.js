import {
    api as ajax,
} from 'services';

export default {
    data() {
        const validatePass = (rule, value, callback) => {
            const newpwd = /^[a-zA-Z0-9]{6,25}$/;
            if (value === '') {
                callback(new Error('请输入新密码'));
            } else if (!newpwd.test(value)) {
                callback(new Error('密码格式不正确'));
            } else {
                callback();
            }
        };
        const validatesurepwd = (rule, value, callback) => {
            if (value === '') {
                callback(new Error('请再次输入密码'));
            } else if (value !== this.ruleForm.newpwd) {
                callback(new Error('两次输入密码不一致!'));
            } else {
                callback();
            }
        };
        return {
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
            asideIndex: '5',
            ruleForm: {
                prepwd: '',
                newpwd: '',
                surepwd: '',
            },
            rules: {
                prepwd: [{
                    required: true,
                    validator: validatePass,
                    trigger: 'blur',
                }],
                newpwd: [{
                    required: true,
                    validator: validatePass,
                    trigger: 'blur',
                }],
                surepwd: [{
                    required: true,
                    validator: validatesurepwd,
                    trigger: 'blur',
                }],
            },
        };
    },
    methods: {
        handleSelect(key, keyPath) {
            this.$router.push(this.menus[key - 1].path);
        },
        submitForm(formName) {
            this.$refs[formName].validate((valid) => {
                if (valid) {
                    ajax.changePassword({
                        oldpassword: this.ruleForm.prepwd,
                        newpassword: this.ruleForm.newpwd,
                    }).then((result) => {
                        this.$message({
                            type: 'success',
                            message: '修改密码成功！',
                        });
                        this.$router.push('login');
                    });
                    return true;
                }
                return false;
            });
        },
    },
};