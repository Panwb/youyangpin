import { api as ajax } from 'services'

export default {
    data () {
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
                    name: '待退费',
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
                date: ''
            },
            form3: {
                companyName:'',
                wuliuid:'',
                money:''
            },
            form4: {
                textarea:''
            }
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
                this.pageList = result.Orders
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
        }
    }
}