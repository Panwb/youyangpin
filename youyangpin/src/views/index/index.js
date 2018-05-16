import { api as ajax } from 'services';

import { mapGetters, mapActions } from 'vuex';

export default {
    data() {
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
                sort: '',
            },
            sortValue: 0,
            vIndex: 0,
        };
    },
    watch: {
        '$route'() {
            if (this.$route.query.keywords) {
                this.searchForm.goodsName = this.$route.query.keywords;
                this.searchForm.pageIndex = 1;
                this.goodsSearch();
            } else {
                this.searchForm.goodsName = '';
                this.searchForm.pageIndex = 1;
                this.goodsSearch();
            }
        },
    },
    mounted() {
        this.goToIndex();
    },
    computed: {
        ...mapGetters([
            'statistics',
        ]),
    },
    methods: {
        ...mapActions([
            'setStatistics',
        ]),
        goToIndex() {
            if (this.$route.query.keywords) {
                this.searchForm.goodsName = this.$route.query.keywords;
            }
            if (sessionStorage.getItem('prePath') !== '/login' && sessionStorage.getItem('prePath') !== '/') {
                //
            } else {
                sessionStorage.setItem('typekey', '0');
                sessionStorage.setItem('typename', '');
            }
            this.getStatistics(this.searchForm.activityType);
            this.goodsSearch();
        },
        goodsSearch() {
            ajax.goodSearch(this.searchForm).then((result) => {
                console.log(result);
                this.pageList = result.Goods;
                this.total = result.RecordCount;
            });
        },
        reset() {
            this.searchForm.lowDailyPrice = '';
            this.searchForm.highDailyPrice = '';
            this.searchForm.lowSales = '';
            this.searchForm.highSales = '';
            this.searchForm.lowCommissionRatio = '';
            this.searchForm.highCommissionRatio = '';
        },
        getStatistics(val) {
            ajax.getStatistics(this.searchForm).then((result) => {
                this.setStatistics(result);
                console.log(`活动类型 ${val} `);
            });
        },
        handleSizeChange(val) {
            this.searchForm.itemsPerPage = val;
            this.goodSearch();
            console.log(`每页 ${val} 条`);
        },
        handleCurrentChange(val) {
            this.searchForm.pageIndex = val;
            this.goodsSearch();
            scrollTo(0, 0);
            console.log(`当前页: ${val}`);
        },
        clickSortField(val, name) {
            this.sortValue = val;
            this.searchForm.sortField = name;
            this.goodsSearch();
        },
        clickVField(name, index) {
            this.vIndex = index;
            name === '全部' ? this.searchForm.verticalFieldCode = '' : this.searchForm.verticalFieldCode = name;
            this.goodsSearch();
        },
        clickType(name) {
            this.searchForm.activityType = name || '';
            this.vIndex = 0;
            this.searchForm.verticalFieldCode = '';
            this.goodsSearch();
            this.getStatistics(name);
        },
    },
};