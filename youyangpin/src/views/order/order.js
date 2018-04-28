import { api as ajax } from 'services'

export default {
    data () {
         var validateDate = (rule, value, callback) => {
            if (value === '') {
              callback(new Error('请选择日期'));
            } else {
              callback();
            }
        };
         var validateName = (rule, value, callback) => {
            if (value === '') {
              callback(new Error('请选择物流公司'));
            } else {
              callback();
            }
        };
        var validateNo = (rule, value, callback) => {
            if (value === '') {
              callback(new Error('请输入物流编号'));
            } else {
              callback();
            }
        };
        var validatePostage = (rule, value, callback) => {
            if (value === '') {
              callback(new Error('请输入邮费'));
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
            status: [
                {
                    name: '待发货',
                    key: 'order1'
                },
                {
                    name: '已发货',
                    key: 'order2'
                }, 
                {
                    name: '已到货',
                    key: 'order3'
                }, 
                {
                    name: '待退货',
                    key: 'order4'
                }, 
                {
                    name: '已退货',
                    key: 'order5'
                }, 
                {
                    name: '待退费',
                    key: 'order6'
                }, 
                {
                    name: '已完成',
                    key: 'order7'
                }, 
                {
                    name: '异常订单',
                    key: 'order8'
                },
            ],
            pageIndex: 1,
            itemsPerPage: 10,
            total: 0,
            currentStatu: '',
            pageList: [],
            asideIndex: '1',
            textarea: '',
            value: null,
            activeName: 'order1',
            dialogVisible1: false,
            dialogVisible2: false,
            dialogVisible3: false,
            dialogVisible4: false,
            activeIndex: '2',
            form: {
                date: null
            },
            rules1: {
              date: [
                { type: 'date', required: true, validator: validateDate, trigger: 'change' }
              ]
            },
            form3: {
                logisticName:'',
                logisticNo:'',
                postage:''
            },
            rules3: {
              logisticName: [
                {  required: true, validator: validateName, trigger: 'blur' }
              ],
              logisticNo: [
                {  required: true, validator: validateNo, trigger: 'blur' }
              ],
              postage: [
                {  required: true, validator: validatePostage, trigger: 'blur' }
              ]
            },
            form4: {
                description:'',
                star: 0
            },
            orderId: null
        }
    },
    created() {
        this.currentStatu = this.status[0]['name']
        this.getPagedOrder()
    },
     methods: {
        handleClick(tab, event) {
            this.pageIndex = 1
            this.currentStatu = tab.label
            this.getPagedOrder()
        },
        getPagedOrder() {
            ajax.getPagedOrder(this.currentStatu, this.pageIndex, this.itemsPerPage).then((result) => {
                this.pageList = result.Orders;
                this.total = result.RecordCount
            })
        },
        handleSizeChange(val) {
            console.log(`每页 ${val} 条`);
            this.itemsPerPage = val
            this.getPagedOrder()
        },
        handleCurrentChange(val) {
            console.log(`当前页: ${val}`);
            this.pageIndex = val
            this.getPagedOrder()
        },
        handleSelect(key, keyPath) {
            this.$router.push(this.menus[key - 1]['path'])
        },
        //排期
        showDialog2(order) {
            this.orderId = order.OrderID;
            this.form.date = order.BroadcastScheduling;
            this.dialogVisible2 = true;
        },
        setBroadcastScheduling() {
            ajax.setBroadcastScheduling(this.orderId,this.form)
            .then((result) => {
                this.$message({
                    type:'success',
                    message:'保存成功'
                });
                this.dialogVisible2 = false;
                this.getPagedOrder()
            })
        },
         //评价
         showDialog4(order) {
             this.orderId = order.OrderID;
             this.dialogVisible4 = true;
             this.form4.description = order.StudioHosToMerchant;
             this.form4.star = order.StudioHosGiveMerchantStars;
         },
         setAssessment() {
             ajax.setAssessment(this.orderId,this.form4)
                 .then((result) => {
                     this.$message({
                         type:'success',
                         message:'保存成功'
                     });
                     this.dialogVisible4 = false;
                     this.getPagedOrder()
                 })
         },
         //申请定向
         showDialog1(order) {
             this.orderId = order.OrderID;
             this.dialogVisible1 = true;
         },
         requestDirectionalPlan() {
             ajax.requestDirectionalPlan(this.orderId)
                 .then((result) => {
                     this.$message({
                         type:'success',
                         message:'保存成功'
                     });
                     this.dialogVisible1 = false;
                     this.getPagedOrder()
                 })
         },
         //填写物流信息
         showDialog3(order) {
             this.orderId = order.OrderID;
             this.form3 = {
                 logisticName:order.TuiHuoLogisticName,
                 logisticNo:order.TuiHuoLogisticNo,
                 postage:order.TuiHuoPostage
             },
             this.dialogVisible3 = true;
         },
         setLogisticsInfo() {
             ajax.setLogisticsInfo(this.orderId,this.form3)
                 .then((result) => {
                     this.$message({
                         type:'success',
                         message:'保存成功'
                     });
                     this.dialogVisible3 = false;
                     this.getPagedOrder()
                 })
         }
    }
}