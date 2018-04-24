import { api as ajax } from 'services'

export default {
    data() {
        return {
            currentPage1: 4,
            goodsId: '',
            applyData: null
        }
    },
    created() {
        if (!this.$route.query.goodsId) {
            this.$router.go(-1)
            return
        }

        console.log(this.$route.query)
        this.goodsId = this.$route.query.goodsId
        this.getGoodsDetail()
    },
    methods: {
        getGoodsDetail() {
            ajax.getGoodsDetail(this.goodsId).then((result) => {
                this.applyData = result;
                console.log(123,result)
                console.log(this.applyData.Shop)
            }) 
        },
        handleSelect(key, keyPath) {
            console.log(key, keyPath);
        },
        handleSizeChange(val) {
            console.log(`每页 ${val} 条`);
        },
        handleCurrentChange(val) {
            console.log(`当前页: ${val}`);
        }
  }
}