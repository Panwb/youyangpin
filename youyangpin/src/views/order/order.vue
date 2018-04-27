<template>
	<div id="app">
		<el-container>
			<!-- header start -->
			<main-header></main-header>
			<!-- header end -->

			<!-- main start -->
			<el-main class="maincontent">
				<div class="wd1200">
					<el-container>
						<el-aside class="asidebox">
							<p class="title">个人中心</p>
							<el-menu class="linklist" :default-active="asideIndex" @select="handleSelect">
								<el-menu-item
										v-for="menu in menus"
										:index="menu.key"
										:key="menu.key">
									{{ menu.title }}
								</el-menu-item>
							</el-menu>
						</el-aside>
						<el-main class="mainbox">
							<p class="title">我的订单</p>
							<div class="content">
								<!--我的订单-->
								<div class="myorder">
									<el-tabs v-model="activeName" @tab-click="handleClick">
										<el-tab-pane
												:label="item.name"
												:name="item.key"
												v-for="item in status"
												:key="item.key">
										</el-tab-pane>
									</el-tabs>
									<div class="titlebox">
										<div class="title1">宝贝</div>
										<div class="title2">销量</div>
										<div class="title3">库存</div>
										<div class="title4">优惠方式</div>
										<div class="title5">定向计划状态</div>
										<div class="title6">订单状态</div>
										<div class="title7">交易操作</div>
									</div>
									<div class="contentbox" v-if="pageList.length>0" v-for="(item,index) in pageList" :key="index">
										<div class="topbox">
											<div class="date">{{ item.datetime }}</div>
											<div class="orderId">订单号:{{ item.OrderNo }}</div>
											<div class="shop">{{ item.ShopName }}</div>
											<div  class="wechat">旺旺号:{{ item.WangWangNo }}</div>
											<div class="phone">联系电话:{{ item.LinkmanPhone }}</div>
										</div>
										<div class="bottombox clear" v-for="(good,index) in item.Goods" :key="index">
											<div class="infobox">
												<div class="imgbox"><a :href="good.GoodsURL" target="view_window"><img :src="good.GoodsImgURL"></a></div>
												<div class="con">
													<p class="name">{{ good.GoodsName }}</p>
													<p class="price">直播专享价:<span class="num">{{ good.LivePrice }}</span> <span class="normal">日常价:{{ good.DailyPrice }}</span></p>
													<p class="money">佣金比例:<span class="num">{{ good.CommissionRatio }}%</span></p>
													<p class="detail">提供多色（{{ good.ColorNum }}种颜色)</p>
													<p class="date">{{ good.NeedSendBack ==='是'? '需要退回样品':''}}</p>
												</div>
											</div>
											<div class="salenum">{{ good.Sales }}</div>
											<div class="leavenum">{{ good.InventoryNum }}</div>
											<div class="quan">{{ good.PreferentialWay ==='拍下立减'?'拍下立减':good.DailyPrice-good.LivePrice+'元优惠券' }}</div>
											
											<div class="planstate"><span>{{ item.DirectionalPlanStatus }}</span></div>
											<div class="planstate"><span>{{ item.OrderStatus }}</span></div>
											<div class="option">
												<div class="box">
													<el-button  class="optbtn" type="text" @click="dialogVisible2 = true">排期</el-button>
													<el-button  class="optbtn"  type="text" @click="dialogVisible4 = true">评价</el-button>
													<el-button  class="optbtn" type="text" @click="dialogVisible1 = true">申请定向</el-button>
													<el-button  class="optbtn" type="text" @click="dialogVisible3 = true">填写物流信息</el-button>
												</div>
											</div>
										</div>
										<div class="tuiaddrress">退货地址：{{ item.ShopAddress }}</div>
									</div>
									<!--排期-->
									<el-dialog :visible.sync="dialogVisible2"  width="30%">
										<el-form :model="form">
											<el-form-item label="排期日期" label-width="80px">
												<el-date-picker
														v-model="form.date"
														type="date"
														placeholder="选择日期">
												</el-date-picker>
											</el-form-item>
										</el-form>
										<div slot="footer" class="dialog-footer">
											<el-button @click="dialogVisible2 = false">取 消</el-button>
											<el-button type="primary" @click="dialogVisible2 = false">确 定</el-button>
										</div>
									</el-dialog>
									<!--评价-->
									<el-dialog :visible.sync="dialogVisible4"  width="30%">
										<el-form :model="form4">
											<el-form-item label="物流编号" label-width="80px">
												<el-input type="textarea" :autosize="{ minRows: 2, maxRows: 4}" placeholder="请输入内容" v-model="form4.textarea"></el-input>
											</el-form-item>
											<el-form-item>
												<div class="block">
													<el-rate  v-model="value" :colors="['#99A9BF', '#F7BA2A', '#FF9900']"></el-rate>
												</div>
											</el-form-item>
										</el-form>
										<div slot="footer" class="dialog-footer">
											<el-button @click="dialogVisible4 = false">取 消</el-button>
											<el-button type="primary" @click="dialogVisible4 = false">确 定</el-button>
										</div>
									</el-dialog>
									<!--申请定向-->
									<el-dialog :visible.sync="dialogVisible1" width="30%">
										<span>确认已在阿里妈妈后台生成定向计划?</span>
										<span slot="footer" class="dialog-footer">
											<el-button @click="dialogVisible1 = false">取 消</el-button>
											<el-button type="primary" @click="dialogVisible1 = false">确 定</el-button>
										</span>
									</el-dialog>
									<!--填写物流信息-->
									<el-dialog :visible.sync="dialogVisible3"  width="30%">
										<el-form :model="form3">
											<el-form-item label="物流公司" label-width="80px">
												<el-input v-model="form3.companyName" auto-complete="off"></el-input>
											</el-form-item>
											<el-form-item label="物流编号" label-width="80px">
												<el-input v-model="form.wuliuid" auto-complete="off"></el-input>
											</el-form-item>
											<el-form-item label="邮费" label-width="80px">
												<el-input v-model="form3.money" auto-complete="off"></el-input>
											</el-form-item>
										</el-form>
										<div slot="footer" class="dialog-footer">
											<el-button @click="dialogVisible3 = false">取 消</el-button>
											<el-button type="primary" @click="dialogVisible3 = false">确 定</el-button>
										</div>
									</el-dialog>
									<div class="pagebox">
										<el-pagination @size-change="handleSizeChange" @current-change="handleCurrentChange" :current-page.sync="pageIndex" :page-size="itemsPerPage" layout="prev, pager, next, jumper" :total="total">
										</el-pagination>
									</div>
								</div>
							</div>
						</el-main>
					</el-container>
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
	import order from './order'
	export default {
  		...order
	}
</script>

<style scoped>
.clear:after{content:'';display:block;clear:both;height:0;overflow:hidden;visibility:hidden;}
.clear{zoom:1;}
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
.maincontent{
	background:#f2f2f2;
	min-height:600px;
}
.maincontent .wd1200{
	height:auto;
}
.asidebox{
	width:208px !important;
	background:#fff;
	border:1px solid #ddd;
	font-size:18px;
	color:#000;
	height:600px;
}
.asidebox .title{
	height: 49px;
    padding-left: 44px;
    line-height: 50px;
    text-align: left;
    font-size: 16px;
    color: #f9513b;
    font-weight:bold;
    border-bottom: 1px solid #e8e8e8;
}
.asidebox .linklist{
	border:none;
}
.asidebox .linklist > li{
	padding-left:44px !important;
	font-size:16px;
}
.asidebox .linklist li.el-submenu{
	padding-left:0 !important;
}
.asidebox .linklist li > div{
	padding-left:44px !important;
	font-size:16px;
}
.asidebox .el-menu-item-group li{
	padding-left:55px !important;
	font-size:16px;
}
.mainbox{
	padding:0 0 0 10px;
}
.mainbox .title{
	height: 38px;
    padding-left: 16px;
    border-bottom: 2px solid #f9513b;
    line-height: 38px;
    text-align: left;
    font-size: 16px;
    color: #000;
    font-weight: bold;
}
.mainbox .content{
	background:#fff;
	margin-top:10px;
	padding:20px;
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
.titlebox{
    border: 1px solid #ebeef5;
    background: #f5f5f5;
    overflow:hidden;
    height:45px;
    line-height:45px;
}
.titlebox > div{
	float:left;
	text-align:center;
}
.titlebox > div.title1{
	width:320px;
}
.titlebox > div.title2{
	width:80px;
}
.titlebox > div.title3{
	width:80px;
}
.titlebox > div.title4{
	width:110px;
}
.titlebox > div.title5{
	width:110px;
}
.titlebox > div.title6{
	width:110px;
}
.titlebox > div.title7{
	width:130px;
}
.contentbox{
	margin-top:30px;
}
.topbox{
	border: 1px solid #ebeef5;
    background: #f5f5f5;
    overflow:hidden;
    height:35px;
    line-height:35px;
}
.topbox > div{
	float:left;
	color:#000;
}
.topbox > div.date{
	margin-left:20px;
	
}
.topbox > div.orderId{
	margin-left:10px;
	color:#666;
}
.topbox > div.shop{
	margin-left:165px;
	color:#666;
}
.topbox > div.shop img{
	width: 15px;
    height: 15px;
    vertical-align: middle;
    margin-right: 5px;
}
.topbox > div.wechat{
	margin-left:80px;
}
.topbox > div.phone{
	margin-left:80px;
	color:#000;
	font-size:14px;
}
.tuiaddrress{
	padding:12px 0 12px 15px;
	border: 1px solid #ebeef5;
	border-top:none;
	font-size:14px;
}
.bottombox{
    font-size:12px;
	border: 1px solid #ebeef5;
	border-bottom:none;
	border-top:none;
}
.bottombox .salenum,.bottombox .leavenum{
	width:80px;
	text-align:center;
	font-size:14px;
	height:110px;
	line-height:110px;
	float:left;
	padding:15px 0;
	border-bottom: 1px solid #ebeef5;
}
.bottombox .quan,.bottombox .planstate,.bottombox .orderstate{
	width:110px;
	text-align:center;
	font-size:14px;
	height:110px;
	line-height:110px;
	float:left;
	padding:15px 0;
	border-bottom: 1px solid #ebeef5;
}
.bottombox .planstate,.bottombox .orderstate,.bottombox .option{
	border-left:1px solid #ebeef5;
}
.bottombox .option{
	float:left;
	width:125px;
	text-align:center;
	height:110px;
	padding:15px 0;
	border-bottom: 1px solid #ebeef5;
}
.contentbox2 .bottombox1 .planstate,.contentbox2 .bottombox1 .orderstate,.contentbox2 .bottombox1 .option{
	border-bottom:none;
}
.contentbox2 .bottombox2{
	border-bottom: 1px solid #ebeef5;
}
.contentbox2 .bottombox2 .salenum,.contentbox2 .bottombox2 .leavenum,.contentbox2 .bottombox2 .quan,.contentbox2 .bottombox2 .infobox{
	border:none
}

.contentbox2 .bottombox2 .planstate span,.contentbox2 .bottombox2 .orderstate span{
	margin-top:-70px;
	display:block;
}
.contentbox2 .bottombox2 .option div.box{
	margin-top:-70px;
}
.bottombox .option button.optbtn{
	display:block;
	width:100%;
	margin:10px 0;
	padding:0;
}
.infobox{
	overflow:hidden;
	float:left;
	width:305px;
	padding:15px 0 15px 15px;
	border-bottom: 1px solid #ebeef5;
}
.infobox .imgbox {
    width: 110px;
    height: 110px;
    margin-right: 10px;
    float:left;
}
.infobox .imgbox img {
    width: 110px;
    height: 110px;
}
.infobox .con{
	float:left;
	width:180px;
}
.infobox .con p {
    margin-bottom:4px;
}
.infobox .con .date, .infobox .con .detail {
    color: #333;
}
.infobox .con p.name {
    height: 25px;
    line-height: 25px;
    overflow: hidden;
    text-overflow: ellipsis;
    white-space: nowrap;
    margin-bottom: 0;
}
.infobox .con .price .num {
    font-size: 14px;
    color: #ff0036;
    padding: 0 6px;
}
.infobox .con .normal {
    text-decoration: line-through;
    float: right;
    color: #989898;
    font-size: 14px;
    margin-top: 3px;
}
.pagebox{
	margin:30px auto;
	text-align:right;
}
/*.el-date-editor.el-input, .el-date-editor.el-input__inner{*/
	/*width:400px;*/
/*}*/
</style>
