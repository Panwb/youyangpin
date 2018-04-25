import { api as ajax } from 'services'

export default {
    data() {
        return {
            currentPage1: 4,
            goodsId: '',
            applyData: null,
            ApplicationForm: {
                GoodIds: [],
                MerchantUserId: null,
                ShopId: null,
                AnchorAbilitySelfReport: null
            }
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
                this.ApplicationForm.ShopId = result.Shop.ShopId;
                console.log('店铺信息',this.applyData.Shop)
                console.log('主播信息',this.applyData.StudioHost)
                console.log('当前申请商品信息',this.applyData.CurrentGood)
            }) 
        },
        //提交申请
        requestApplication() {
            // {
            //     "GoodIds": [
            //     "sample string 1",
            //     "sample string 2"
            // ],
            //     "MerchantUserId": "sample string 1",
            //     "ShopId": "sample string 2",
            //     "AnchorAbilitySelfReport": "sample string 3"
            // }
            ajax.requestApplication(this.ApplicationForm)
                .then((result) => {
                    this.$message({type:"success",message:"提交成功"});
                    console.log(result)
                })
                .catch(error => {
                    this.$message({type:"warning",message:"提交成功"});
                    console.log(error)
                })
        },
        //修改个人信息
        editPersonalMeg() {
            this.$router.push('user')
        },
        //完善收货地址
        improveAddress() {
            this.$router.push('user')
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