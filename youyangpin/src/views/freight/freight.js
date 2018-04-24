import { api as ajax } from 'services'

export default {
    data() {
        return {
            dialogVisible: false,
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
            asideIndex: '3',
            freightData: '1',
            tableData: [
                {
                    no: '1',
                    applytime: '2018-01-03',
                    applymoney: '188',
                    dealtime:'2018-09-08',
                    dealstate:'已发送'
                },
                {
                    no: '2',
                    applytime: '2018-01-03',
                    applymoney: '188',
                    dealtime:'2018-09-08',
                    dealstate:'已发送'
                },
                {
                    no: '3',
                    applytime: '2018-01-03',
                    applymoney: '188',
                    dealtime:'2018-09-08',
                    dealstate:'已发送'
                },
                {
                    no: '4',
                    applytime: '2018-01-03',
                    applymoney: '188',
                    dealtime:'2018-09-08',
                    dealstate:'已发送'
                },
                {
                    no: '5',
                    applytime: '2018-01-03',
                    applymoney: '188',
                    dealtime:'2018-09-08',
                    dealstate:'已发送'
                }
            ]
        }
    },
    created() {
        this.getUserDetail()
        this.getMyRequests()
    },
    methods: {
        getUserDetail() {
            ajax.getUserDetail().then((result) => {
                this.freightData = result
            })
        },
        // 提现记录
        getMyRequests() {
            ajax.getMyRequests().then((result) => {

            })
        },
        requestMoney() {

        },
        handleSelect(key, keyPath) {
            this.$router.push(this.menus[key - 1]['path'])
        },
        handleClick(tab, event) {
            console.log(tab, event);
        },
        handleClose(done) {
        this.$confirm('确认关闭？')
          .then(_ => {
            done();
          })
          .catch(_ => {});
      }
    }
}