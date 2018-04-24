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
        var validateqqId= (rule, value, callback) => {
            var qqreg=/[1-9]\\d{4,14}/;  
            if (!qqreg.test(value)) {
                callback(new Error('qq号码格式不正确'));
            }else {
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
                // DailyEndTime: ''
                userName: '',
                zhifuId:'',
                height:'',
                weight:'',
                size:'',
                shoeSize:'',
                address:'',
                linkName:'',
                linkPhone:'',
                tkName:'',
                type: [],
                qqId:'',
                startTime: '',
                endTime: ''
            },
            rules: {
                userName: [
                    { required: true, validator: validateuserName, trigger: 'blur' }
                 ],
                zhifuId: [
                    { required: true, validator: validateuserzhifuId, trigger: 'blur' }
                ],
                height: [
                    { required: true, validator: validateheight, trigger: 'blur' }
                ],
                weight: [
                    { required: true, validator: validateweight, trigger: 'blur' }
                ],
                shoeSize: [
                    { required: true, validator: validateshoeSize, trigger: 'blur' }
                ],
                address: [
                    { required: true, validator: validateaddress, trigger: 'blur' }
                ],
                linkName: [
                    { required: true, validator: validatelinkName, trigger: 'blur' }
                ],
                linkPhone: [
                    { required: true, validator: validatelinkPhone, trigger: 'blur' }
                ],
                qqId: [
                    { validator: validateqqId, trigger: 'blur' }
                ],
                type: [
                    { type: 'array', required: true, message: '请至少选择一个垂直领域', trigger: 'change' }
                ]
            }
        }
    },
    created() {
        this.getUserDetail()
    },
     methods: {
        getUserDetail() {
            ajax.getUserDetail().then((result) => {

            })
        },
        handleSelect(key, keyPath) {
            this.$router.push(this.menus[key - 1]['path'])
        },
        submitForm(formName,formValue) {
            this.$refs[formName].validate((valid) => {
                if (valid) {
                    this.$router.go(-1);
                } else {
                    console.log('error submit!!');
                    return false;
                }
            });
        }
    }
}