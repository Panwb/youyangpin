import {
    api as ajax,
} from 'services';

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
                AnchorAbilitySelfReport: null,
            },
            isChecked: [],
            isShowChoose: true,
        };
    },
    created() {
        if (!this.$route.query.goodsId) {
            this.$router.go(-1);
            return;
        }

        console.log(this.$route.query);
        this.goodsId = this.$route.query.goodsId;
        sessionStorage.removeItem('goodid');
        this.getGoodsDetail();
    },
    methods: {
        getGoodsDetail() {
            this.ApplicationForm.GoodIds = [];
            this.isShowChoose = false;
            ajax.getGoodsDetail(this.goodsId)
                .then((result) => {
                    if (result) {
                        this.applyData = result;
                        this.ApplicationForm.ShopId = result.Shop.ShopId;
                        this.ApplicationForm.MerchantUserId = result.Shop.UserId;
                        this.ApplicationForm.AnchorAbilitySelfReport = this.applyData.StudioHost.Remark;
                        this.applyData.RelatedGoods.forEach((item, index) => {
                            this.$set(this.isChecked, index, false)
                        });
                        this.isShowChoose = true;
                    }
                });
        },
        // 提交申请
        requestApplication() {
            let GoodsIds = [];
            this.isChecked.forEach((item, index) => {
                if (item) {
                    GoodsIds.push(this.applyData.RelatedGoods[index].GoodsId);
                }
            });
            GoodsIds.push(this.applyData.CurrentGood.GoodsId);
            this.ApplicationForm.GoodIds = GoodsIds;
            ajax.requestApplication(this.ApplicationForm)
                .then((result) => {
                    this.$message({
                        type: 'success',
                        message: '提交成功，等待商家审核',
                    });
                    this.$router.push('/applyrecord');
                }, error => {
                    this.$message({
                        type: 'warning',
                        message: error,
                    });
                });
        },
        // 修改个人信息
        editPersonalMeg() {
            sessionStorage.setItem('goodid', this.$route.query.goodsId);
            this.$router.push('user');
        },
        // 完善收货地址
        improveAddress() {
            sessionStorage.setItem('goodid', this.$route.query.goodsId);
            this.$router.push('user');
        },
        handleCheckAllChange(val) {
            this.applyData.RelatedGoods.forEach((item, index) => {
                this.$set(this.isChecked, index, val);
            });
        },
        handleSelect(key, keyPath) {
            console.log(key, keyPath);
        },
        handleSizeChange(val) {
            console.log(`每页 ${val} 条`);
        },
        handleCurrentChange(val) {
            console.log(`当前页: ${val}`);
        },
        formatDate(date, type) {
            return this.util.formatDate(date, type);
        },
    },
};