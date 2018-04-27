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
            amount: null,
            tableData: []
        }
    },
    created() {
        this.getUserDetail();
        this.getMyRequests()
    },
    methods: {
        getUserDetail() {
            ajax.getUserDetail().then((result) => {
                this.freightData = result
            })
        },
        getMyRequests() {
            ajax.getMyRequests().then((result) => {
                this.tableData = result;
            })
        },
        requestMoney() {
            ajax.requestMoney(this.amount).then((result) => {
                this.$message({
                    type:'success',
                    message:'提现成功'
                });
                this.dialogVisible = false;
                this.getUserDetail();
                this.getMyRequests();
            })
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