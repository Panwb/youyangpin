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
            this.ApplicationForm.GoodIds = [];
            ajax.getGoodsDetail(this.goodsId)
                .then((result) => {
                    this.applyData = result;
                    this.ApplicationForm.ShopId = result.Shop.ShopId;
                    this.ApplicationForm.MerchantUserId = result.Shop.UserId;
                    // console.log('店铺信息',this.applyData.Shop)
                    // console.log('主播信息',this.applyData.StudioHost)
                    // console.log('当前申请商品信息',this.applyData.CurrentGood)
                    // console.log('店铺同类商品',this.applyData.RelatedGoods)
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
            let RelatedGoodsIds = [] , CurrentGoodsIds = [];
            if(this.applyData.RelatedGoods.length) {
                this.applyData.RelatedGoods.forEach(item => {
                    RelatedGoodsIds.push(item.GoodsId)
                });
            }
            if(this.applyData.CurrentGood.length) {
                this.applyData.CurrentGood.forEach(item => {
                    CurrentGoodsIds.GoodsId.push(item.GoodsId)
                });
            }
            this.ApplicationForm.GoodIds = [...RelatedGoodsIds,...CurrentGoodsIds]
            ajax.requestApplication(this.ApplicationForm)
                .then((result) => {
                    this.$message({type:"success",message:"提交成功"});
                })
                .catch(error => {
                    this.$message({type:"warning",message:error});
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