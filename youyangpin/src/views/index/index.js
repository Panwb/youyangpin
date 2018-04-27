import { api as ajax } from 'services'

import { mapGetters, mapActions } from 'vuex'

export default {
    data () {
        return {
            pageList: [],
            total: 0,
            searchForm: {
                pageIndex: 1,
                itemsPerPage: 40,
                goodsName: '',
                verticalFieldCode: '',
                activityType: '',
                lowSales: '',
                highSales: '',
                lowDailyPrice: '',
                highDailyPrice: '',
                lowCommissionRatio: '',
                highCommissionRatio: '',
                sortField: '',
                sort: ''
            },
            sortValue: 0
        }
    },
    watch: {
        '$route'() {
            if (this.$route.query.keywords) {
                this.searchForm.goodsName = this.$route.query.keywords;
                this.searchForm.pageIndex = 1;
                this.goodsSearch()
            }
            else {
                this.searchForm.goodsName = '';
                this.searchForm.pageIndex = 1;
                this.goodsSearch()
            }
        }
    },
    created() {
        if (this.$route.query.keywords) {
            this.searchForm.goodsName = this.$route.query.keywords
        }
        this.goodsSearch();
        this.getStatistics(this.searchForm.activityType)
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
            ajax.goodSearch(this.searchForm).then((result) => {
                console.log(result);
                this.pageList = result.Goods;
                this.total = result.RecordCount
            })
        },
        getStatistics(val) {
            ajax.getStatistics(this.searchForm).then((result) => {
                this.setStatistics(result)
                console.log(`活动类型 ${val} `);
            })
        },
        handleSizeChange(val) {
            this.searchForm.itemsPerPage = val;
            this.goodSearch()
            console.log(`每页 ${val} 条`);
        },
        handleCurrentChange(val) {
            this.searchForm.pageIndex = val
            this.goodsSearch()
            console.log(`当前页: ${val}`);
        },
        clickSortField(val,name) {
            this.sortValue = val;
            this.searchForm.sortField = name;
            this.goodsSearch();
        },
        clickVField(name) {
            name === '全部' ? this.searchForm.verticalFieldCode = "" : this.searchForm.verticalFieldCode = name;
            this.goodsSearch();
        },
        clickType(name) {
            this.searchForm.activityType = name;
            this.goodsSearch();
            this.getStatistics(name)
        }
    }
}