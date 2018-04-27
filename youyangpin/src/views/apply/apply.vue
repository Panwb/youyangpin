<template>
	<div id="app">
		<el-container>
			<main-header></main-header>
			<!-- main start -->
			<el-main>
				<div class="wd1200 applybox" v-if="applyData">
					<el-card class="box-card shopbox" shadow="never">
						<div slot="header" class="clearfix title">
							<span>店铺信息</span>
						</div>
						<div  class="text item">
							<div class="txt">
								<div class="box">
									<span class="tianmao"><img src="~assets/images/tianmao.png" class="image"></span>
									<span class="name">店铺:{{ applyData.Shop.ShopName }}</span>
									<span class="wangwang"></span>
								</div>
								<span class="line"></span>
								<div class="box">
									<span class="lab">描述 <i class="num">{{ applyData.Shop.DescriptionMatch }}</i></span>
									<span class="lab">服务 <i class="num">{{ applyData.Shop.ServiceAttitude }}</i></span>
									<span class="lab">物流 <i class="num">{{ applyData.Shop.LogisticsService }}</i></span>
								</div>
								<span class="line"></span>
								<div class="box">
									<span class="type">当前活动类型：{{ applyData.CurrentGood.ActivityType }}</span>
								</div>
							</div>
						</div>
					</el-card>
					<el-card class="box-card personbox" shadow="never">
						<div slot="header" class="clearfix title">
							<span>对主播的要求</span>
						</div>
						<div  class="text item">
							<div class="txt">
								{{ applyData.CurrentGood.MerchantToStudioHostDemand }}
							</div>
						</div>
					</el-card>
					<el-card class="box-card goodbox" shadow="never">
						<div slot="header" class="clearfix title">
							<span>当前商品详情</span>
						</div>
						<div  class="text item">
							<div class="txt">
								<ul class="list">
									<li><div class="imgbox"><img :src="applyData.CurrentGood.GoodsImgURL" class="image"></div></li>
									<li>
										<div class="infobox">
											<p class="name">{{ applyData.CurrentGood.GoodsName }}</p>
											<p class="price">直播专享价:<span class="num">{{ applyData.CurrentGood.LivePrice }}</span> <span class="normal">日常价:{{ applyData.CurrentGood.DailyPrice }}</span></p>
											<p class="money">佣金比例:<span class="num">{{ applyData.CurrentGood.CommissionRatio }}%</span></p>
											<p class="date">活动日期：{{ formatDate(applyData.CurrentGood.ActivityBeginTime) }}-{{ formatDate(applyData.CurrentGood.ActivityEndTime) }}</p>
											<p class="detail">{{ applyData.CurrentGood.IsProvideMulticolor === '是' ?  '提供多色（' + applyData.CurrentGood.ColorNum + '中颜色）' : ''}}</p>
										</div>
									</li>
									<li>
										<div class="detailbox">
											<p class="title">销量</p>
											<p class="num">{{ applyData.CurrentGood.Sales }}</p>
										</div>
									</li>
									<li>
										<div class="detailbox">
											<p class="title">库存</p>
											<p class="num">{{ applyData.CurrentGood.InventoryNum }}</p>
										</div>
									</li>
									<li>
										<div class="detailbox">
											<p class="title">已申请数/供样数</p>
											<p class="num">{{ applyData.CurrentGood.RequestQuantity }}/{{ applyData.CurrentGood.SupplyNum }}</p>
										</div>
									</li>
									<li>
										<div class="detailbox">
											<p class="title">优惠方式</p>
											<p class="num">{{applyData.CurrentGood.PreferentialWay ==='拍下立减'?'拍下立减':applyData.CurrentGood.DailyPrice-applyData.CurrentGood.LivePrice+'元优惠券'}}</p>
										</div>
									</li>
									<li>
										<div class="detailbox last">
											<p class="title">是否需要退回样品</p>
											<p class="num">是</p>
										</div>
									</li>
								</ul>
							</div>
						</div>
					</el-card>

					<el-card class="box-card goodbox shopgoods" shadow="never">
						<div slot="header" class="clearfix title">
							<span>店铺同类商品</span>
						</div>
						<div class="text item">
							<div class="txt" v-for="(item,index) in applyData.RelatedGoods" :key="item.GoodsId">
								<ul class="list">
									<li v-if="isShowChoose" class="checkbox"> <el-checkbox size="medium" v-model="isChecked[index]"></el-checkbox></li>
									<li><div class="imgbox"><img :src="item.GoodsImgURL" class="image"></div></li>
									<li>
										<div class="infobox">
											<p class="name">{{ item.GoodsName }}</p>
											<p class="price">直播专享价:<span class="num">{{ item.LivePrice }}</span> <span class="normal">日常价:{{ item.DailyPrice }}</span></p>
											<p class="money">佣金比例:<span class="num">{{ item.CommissionRatio }}%</span></p>
											<p class="date">活动日期：{{ formatDate(item.ActivityBeginTime) }}-{{ formatDate(item.ActivityEndTime) }}</p>
											<p class="detail">{{ item.SellingPointDescribe }}</p>
										</div>
									</li>
									<li>
										<div class="detailbox">
											<p class="title">销量</p>
											<p class="num">{{ item.Sales }}</p>
										</div>
									</li>
									<li>
										<div class="detailbox">
											<p class="title">库存</p>
											<p class="num">{{ item.InventoryNum }}</p>
										</div>
									</li>
									<li>
										<div class="detailbox">
											<p class="title">已申请数/供样数</p>
											<p class="num">{{ item.RequestQuantity }}/{{ item.SupplyNum }}</p>
										</div>
									</li>
									<li>
										<div class="detailbox">
											<p class="title">优惠方式</p>
											<p class="num">{{applyData.CurrentGood.PreferentialWay ==='拍下立减'?'拍下立减':applyData.CurrentGood.DailyPrice-applyData.CurrentGood.LivePrice+'元优惠券'}}</p>
										</div>
									</li>
									<li>
										<div class="detailbox last">
											<p class="title">是否需要退回样品</p>
											<p class="num">是</p>
										</div>
									</li>
								</ul>
							</div>
						</div>
					</el-card>
					<el-card class="box-card pinfobox" shadow="never" v-if="applyData.StudioHost.LinkmanName||applyData.StudioHost.Address||applyData.StudioHost.LinkmanPhone">
						<div slot="header" class="clearfix title">
							<span>{{ applyData.StudioHost.LinkmanName }}</span>
						</div>
						<div class="text item">
							<div class="txt address">
								{{ applyData.StudioHost.Address }}
							</div>
							<div class="txt phone">{{ applyData.StudioHost.LinkmanPhone }}</div>
							<span class="txt opt"><el-button @click="editPersonalMeg" type="text">修改</el-button></span>
						</div>
					</el-card>
					<div class="remarkbox">
						<el-input type="textarea" v-model="ApplicationForm.AnchorAbilitySelfReport" placeholder="请简要描述一下您对商品的带货能力和优势"></el-input>
						<!--<div>-->
						<!--<span class="tip">(商家最多接受1000服务费)</span>-->
						<!--<el-input></el-input> -->
						<!--<el-checkbox>我想要商家付费</el-checkbox>-->
						<!--</div>-->
						<!--<div>-->
						<!--<span class="tip">(商家最多接受50%的返佣)</span>-->
						<!--<el-input></el-input> -->
						<!--<el-checkbox>我想要调整佣金比例</el-checkbox>-->
						<!--</div>-->
						<!--<div>-->
						<!--<span class="tip">(商家最大接受50元的优惠力度)</span>-->
						<!--<el-input></el-input> -->
						<!--<el-checkbox>我想要商家调整优惠力度</el-checkbox>-->
						<!--</div>-->
					</div>
					<div class="txt addaddressbox" @click="improveAddress"><el-button>+完善收货地址</el-button> </div>
					<div class="txt applybtnbox"><el-button @click="requestApplication" type="text">提交申请</el-button></div>
				</div>
			</el-main>
			<!-- main end -->

			<!-- footer start -->
			<el-footer>
				<main-footer></main-footer>
			</el-footer>
			<!-- footer end -->
		</el-container>
	</div>
</template>

<script type="text/babel">
import apply from './apply'
export default {
    ...apply
}
</script>

<style>
.applybox{
	margin-top:15px;
}
.optbox{
	background-color: #f2f2f2;
    height: 40px;
    line-height:40px;
    font-size:14px;
}
.optbox span{
	cursor:pointer;
}
.optbox span.loginbtn{
	color:#fe3026;
	margin-right:25px;
}
.seabox{
	margin-top:18px;
}
.searchbox{
   padding:20px 0;
}
.searchbox .logo{
	height:69px;
}
.searchbox  .el-input{
	width:280px;
	float:left;
}
.searchbox  .el-input input{
	border-radius:4px 0 0 4px;
	border-color:#f9513b;
	border-width:2px;
}
.searchbox .sea-btn{
	background:#f9513b;
	color:#fff;
	border:none;
	float:left;
	border-radius:0 4px 4px 0;
	height:40px;
	font-size:16px;
}
.navbox .el-header{
  height:50px !important;
  padding:0;
  background:#261f1e;
  font-size:16px;
}
.navbox .el-menu--horizontal>.el-menu-item{
  height:50px;
  line-height:50px;
  margin-right:30px;
}

.el-footer{
   height:auto !important;
   background-color: #363636;
   padding:20px;
}
.el-footer ul {
    width: 711px;
    height: 62px;
    margin: 0 auto;
    font-size: 0;
    text-align: center;
    line-height: 62px;
    border-bottom: 1px dashed #fff;
}
.el-footer ul li, .el-footer ul li a {
    display: inline-block;
}
.el-footer ul li a {
    height: 18px;
    padding: 0 18px;
    line-height: 18px;
    font-size: 14px;
    color: #fff;
}
.el-footer ul li:after {
    content: '|';
    font-size: 18px;
    color: #fff;
}
.el-footer ul li:last-child:after {
    content: '';
    font-size: 18px;
    color: #fff;
}
.el-footer .copyright{
	text-align:center;
	color:#fff;
	margin:20px auto;
	font-size:14px;
}
.el-footer .copyright a{
	color:#fff;
}
.el-card{
	border-radius:0;
	margin-bottom:30px;
}
.applybox .el-card__header{
	height:48px;
	line-height:48px;
	padding:0;
	padding-left:10px;
	background:#f5f5f5;
	font-size:18px;
	color:#333;
}
.el-card .txt span{
	display:inline-block;
	font-size:16px;
	color:#333;
}
.el-card .txt{
    padding:5px 0;
	overflow:hidden;
}
.el-card .box,.el-card .line{
	float:left;
}
.el-card .box{
	height:50px;
	line-height:50px;
}
.el-card .box .lab{
	padding:0 10px;
	font-size:14px;
}
.el-card .box .lab .num{
	color:#ff0036;
	font-style:normal;
	margin-left:3px;
}
.el-card .box .type{
	font-size:14px;
}
.el-card .tianmao img{
	vertical-align: middle;
    margin-top: -4px;
    margin-right:6px;
}
.el-card .wangwang img{
	vertical-align: middle;
    margin-top: -4px;
    margin-left:6px;
}
.el-card .line{
	display:block;
	background:#ddd;
	width:1px;
	height:50px;
    margin:0 20px;
    position:relative;
}
.goodbox .list{
	overflow:hidden;
}
.goodbox .txt{
	padding:0;
}
.goodbox .list li{
	float:left
}
.goodbox .imgbox{
	width:120px;
	height:120px;
	margin-right:12px;
}
.goodbox .imgbox img{
	width:120px;
	height:120px;
}
.goodbox .infobox{
	width:325px;
	margin-right:150px;
	color:#656565;
	text-align:left;
}
.goodbox .infobox p{
	margin-bottom:5px;
}
.goodbox .infobox p.name{
	height: 25px;
    line-height: 25px;
    overflow: hidden;
    text-overflow:ellipsis;
    white-space: nowrap;
    margin-bottom:0;
}
.goodbox .infobox .price .num{
	font-size:16px;
	color:#ff0036;
	padding:0 6px;
}
.goodbox .infobox .normal{
	text-decoration: line-through;
    margin-left:15px;
    color: #989898;
    font-size: 14px;
    margin-top: 3px;
}
.goodbox .infobox .money .num{
	color:#ff0036;
	padding:0 10px;
}
.goodbox .infobox .date,.goodbox .infobox .detail{
	color:#333;
}

.goodbox .detailbox{
	padding:0 21px;
}
.goodbox .detailbox.last{
	padding-right:0;
}
.goodbox .detailbox p{
	text-align:center;
}
.goodbox .detailbox p.title{
	color: #989898;
    height: 25px;
    line-height: 25px;
    margin-bottom: 8px;
}
.shopgoods .el-card__body{
	padding:0 10px;
}
.shopgoods .txt{
	border-bottom:1px solid #e3e3e3;
	padding:20px 0 20px 10px;
	margin-bottom:-1px;
}
.shopgoods .checkbox{
	padding:50px 10px 50px 0px;
}
.shopgoods .checkbox .el-checkbox__inner{
	width:18px;
	height:18px;
	border:1px solid #989898;
}
.shopgoods .checkbox .el-checkbox__inner::after{
	width:4px;
	height:8px;
	left:6px;
	top:1px;
}
.shopgoods .infobox{
	margin-right:120px;
}
.pinfobox{
	width:500px;
	border:1px solid #f35f17;
	float:right;
	padding:10px 20px 0;
	position:relative;
	overflow: initial;
	margin-bottom:0;
}
.pinfobox .el-card__header{
	background:#fff;
	font-size:14px;
	padding:0;
	height:35px;
	line-height:35px;
	text-align:right;
}
.pinfobox .el-card__body{
	padding:10px 0;
	font-size:14px;
}
.pinfobox .el-card__body .address span{
	margin-right:5px;
	font-size:14px;
}
.pinfobox .el-card__body .phone{
	margin-bottom:20px;
	text-align:right;
}
.pinfobox .el-card__body .opt button{
	padding:0;
	float:right;
	margin:10px 0;
}
.pinfobox .el-card__body .opt span{
	font-size:12px;
	color:#656565;
}
.applybtnbox{
	font-size: 12px;
    width: 180px;
    height: 50px;
    line-height: 50px;
    text-align: center;
    color: #fff;
    float:right;
    background: #f35f17;
    color: #fff;
    padding: 0;
    clear:both;
}
.applybtnbox .el-button--text {
    color: #fff;
}
.applybtnbox .el-button{
	width:100%;
	height:100%;
}
.applybtnbox span{
	font-size:18px;
	color:#fff;
}
.addaddressbox{
	clear:both;
	font-size:16px;
	width:160px;
	height:50px;
	line-height:35px;
	float:right;
	margin-bottom:20px;
}
.addaddressbox button{
	width:100%;
	height:100%;
	border-radius:0;
	padding:0;
}
.remarkbox{
	float: right;
    margin-top: 10px;
    width: 460px;
    padding: 0;
    clear: both;
}
.remarkbox textarea{
	height:120px;
}
.remarkbox div{
	margin-bottom:15px;
	/*overflow:hidden;*/
}
/*.remarkbox .el-input,.remarkbox .el-checkbox{*/
	/*float:right;*/
/*}*/
.remarkbox .el-input{
	width:500pxpx;
	height:25px;
	line-height:25px;
	margin:5px ;
}
.remarkbox .el-input input{
	height:22px;
	line-height:22px;
}
.remarkbox .tip{
	color:#999;
	font-size:12px;
	margin-top:1px;
	float:right;
}
</style>