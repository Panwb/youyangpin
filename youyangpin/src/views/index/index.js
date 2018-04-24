import { api as ajax } from 'services'

import { mapGetters, mapActions } from 'vuex'

export default {
    data () {
        return {
            pageIndex: 1,
            itemsPerPage: 10,
            pageList: [],
            total: 0,
            goodsName: '',
            verticalFieldCode: '',
            activityType: '',
            sales: '',
            lowDailyPrice: '',
            highDailyPrice: '',
            commissionRatio: '',
            sortField: '',
            sort: ''
        }
    },
    watch: {
        '$route'() {
            if (this.$route.query.keywords) {
                this.goodsName = this.$route.query.keywords
                this.pageIndex = 1
                this.goodsSearch()
            }
            else {
                his.goodsName = ''
                this.pageIndex = 1
                this.goodsSearch()
            }
        }
    },
    created() {
        if (this.$route.query.keywords) {
            this.goodsName = this.$route.query.keywords
        }
        this.goodsSearch()
        this.getStatistics()
    },
    computed: {
        ...mapGetters([
            'statistics'
        ])
    },
    methods: {
        ...mapActions([
            'setStatistics'
        ]),
        goodsSearch() {
            ajax.goodSearch(this.goodsName, this.verticalFieldCode, this.activityType, this.sales, this.lowDailyPrice, this.highDailyPrice, this.commissionRatio, this.pageIndex, this.itemsPerPage, this.sortField, this.sort).then((result) => {
                console.log(result)
                this.pageList = result.Goods
                this.total = result.RecordCount
            })
        },
        getStatistics() {
            ajax.getStatistics().then((result) => {
                this.setStatistics(result)
            })
        },
        handleSizeChange(val) {
            this.itemsPerPage = val
            this.goodSearch()
            console.log(`每页 ${val} 条`);
        },
        handleCurrentChange(val) {
            this.pageIndex = val
            this.goodsSearch()
            console.log(`当前页: ${val}`);
        }
    }
}