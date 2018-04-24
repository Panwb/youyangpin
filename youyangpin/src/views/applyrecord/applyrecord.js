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
                    name: '所有记录',
                    key: 'order1'
                },
                {
                    name: '待审核',
                    key: 'order2'
                }, 
                {
                    name: '审核通过',
                    key: 'order3'
                }, 
                {
                    name: '审核不通过',
                    key: 'order4'
                }
            ],
            asideIndex: '2',
            activeName: 'order1',
            currentStatu: '',
            pageIndex: 1,
            itemsPerPage: 10,
            total: 0,
            pageList: []
        }
    },
    created() {
        this.currentStatu = this.status[0]['name']
        this.getPagedRequest()
    },
    methods: {
        handleSelect(key, keyPath) {
            this.$router.push(this.menus[key - 1]['path'])
        },
        handleClick(tab, event) {
            this.pageIndex = 1
            this.currentStatu = tab.label
            this.getPagedRequest()
        },
        getPagedRequest() {
            ajax.getPagedRequest(this.currentStatu, this.pageIndex, this.itemsPerPage).then((result) => {
                this.pageList = result.Orders
                this.total = result.RecordCount
            })
        },
        handleSizeChange(val) {
            console.log(`每页 ${val} 条`);
            this.itemsPerPage = val
            this.getPagedRequest()
        },
        handleCurrentChange(val) {
            console.log(`当前页: ${val}`);
            this.pageIndex = val
            this.getPagedRequest()
        }
    }
}