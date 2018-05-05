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
											<div class="shop"><span :class="item.ShopType=='淘宝店'?'icon icon-tao':'icon icon-tian'"></span>{{ item.ShopName }}</div>
											<div class="wechat">微信号:{{ item.WeChat }}</div>
											<div class="phone">联系电话:{{ item.LinkmanPhone }}</div>
										</div>
										<div class="bottombox clear" v-for="(good,index) in item.Goods" :key="index">
											<div class="infobox">
												<div class="imgbox"><a :href="good.GoodsURL" target="view_window"><img :src="good.GoodsImgURL"></a></div>
												<div class="con">
													<p class="name">{{ good.GoodsName }}</p>
													<p class="price">直播专享价:<span class="num">{{ good.LivePrice }}</span> <span class="normal">日常价:{{ good.DailyPrice.toFixed(2) }}</span></p>
													<p class="money">佣金比例:<span class="num">{{ good.CommissionRatio }}%</span></p>
													<p class="detail">{{ good.IsProvideMulticolor === '是' ?  '提供多色（' + good.ColorNum + '中颜色）' : '' }}</p>
													<p class="date">{{ good.NeedSendBack ==='是'? '需要退回样品':''}}</p>
												</div>
											</div>
											<div class="salenum">{{ good.Sales }}</div>
											<div class="leavenum">{{ good.InventoryNum }}</div>
											<div class="quan">
											 <div class="outer">
												 <div class="inner">
												 {{ good.PreferentialWay ==='拍下立减'?'拍下立减':(good.DailyPrice-good.LivePrice).toFixed(2)+'元优惠券' }}
												  <el-button type="text" class="copybox">复制优惠券链接</el-button>
												 </div>
											 </div>
											</div>
									  	</div>
										<!--申请计划状态-->
										<div class="planstate">
											<div class="outer">
											   <div class="inner" >{{ item.DirectionalPlanStatus }} 
											    <el-button type="text" class="copybox">复制定向链接</el-button>
											   </div>
											 </div>
									    </div>
										<div class="orderstate">
										  <div class="outer">
										   <div class="inner ycstate" v-if="item.OrderStatus === '异常订单'">{{item.OrderStatus}}<div class="reason">(<span class="words" title="异常原因原因异常原因原因">异常原因原因</span>)</div></div>  
										    <div class="inner fhstate" v-else-if="item.OrderStatus === '已发货'">{{item.OrderStatus}}<div class="wlnum">(<span class="words" title="物流公司名称">物流单号</span>)</div></div>
										   <div class="inner wcstate" v-else-if="item.OrderStatus === '已完成'">{{item.OrderStatus}}</div>  
										   <div class="inner" v-else>{{item.OrderStatus}}</div> 
										  </div>
										</div>
										<div class="option">
										   <div class="outer">
												<div class="box inner">
                                                  
												  <el-button v-if="item.OrderStatus === '已到货' || item.OrderStatus === '待退货'" class="optbtn" type="text" @click="showDialog2(item)">排期</el-button>
												  <el-button v-if="item.OrderStatus === '已完成' && !item.StudioHosToMerchant && !item.StudioHosGiveMerchantStars" class="optbtn" type="text" @click="showDialog4(item)">评价</el-button>
												  <el-button v-if="item.OrderStatus === '待发货' || item.OrderStatus === '已发货' || item.OrderStatus === '已到货' || item.OrderStatus === '待退货'" class="optbtn" type="text" @click="showDialog1(item)">申请定向</el-button>
												  <el-button v-if="item.OrderStatus === '待退货' && item.NeedSendBack" class="optbtn" type="text" @click="showDialog3(item)">填写物流信息</el-button>
                                                   <el-button v-if="item.OrderStatus === '已到货' || item.OrderStatus === '待退货'" class="optbtn" type="text" @click="showDialog5(item)">卖点介绍</el-button>
                                                    <el-button v-else class="optbtn" type="text" >复制宝贝地址</el-button>
												</div>
											</div>
										</div>
										<div class="tuiaddrress">退货地址：{{ item.ShopAddress }}</div>
									</div>
									<!--排期-->
									<el-dialog :visible.sync="dialogVisible2" width="500px">
										<el-form :model="form" :rules="rule1" ref="form" class="form">
											<el-form-item label="排期开始时间" prop="date" label-width="120px">
												<el-date-picker v-model="form.date" format="yyyy/MM/dd" value-format="yyyy/MM/dd" type="date" :picker-options="pickerOptions0" placeholder="请选择排期开始时间"></el-date-picker>
											</el-form-item>
											<div class="pqtip">直播前请与商家联系确认优惠的方式</div>
										</el-form>
										<div slot="footer" class="dialog-footer">
											<el-button @click="dialogVisible2 = false">取 消</el-button>
											<el-button type="primary" @click="setBroadcastScheduling">确 定</el-button>
										</div>
									</el-dialog>
									<!--评价-->
									<el-dialog :visible.sync="dialogVisible4" width="500px">
										<el-form :model="form4" class="form4">
											<el-form-item label="评价" label-width="80px">
												<el-input type="textarea" :autosize="{ minRows: 2, maxRows: 4}" placeholder="请输入内容" v-model="form4.description"></el-input>
											</el-form-item>
											<el-form-item>
												<div class="block">
													<el-rate v-model="form4.star" :colors="['#99A9BF', '#F7BA2A', '#FF9900']" show-text></el-rate>
												</div>
											</el-form-item>
										</el-form>
										<div slot="footer" class="dialog-footer">
											<el-button @click="dialogVisible4 = false">取 消</el-button>
											<el-button type="primary" @click="setAssessment">确 定</el-button>
										</div>
									</el-dialog>
									<!--申请定向-->
									<el-dialog :visible.sync="dialogVisible1" width="400px" class="sqdxdialog">
										<span>确认已在淘宝联盟申请计划?</span>
										<div class="dxtip">还未申请?<a href="">点这</a>现在去申请</div>
										<span slot="footer" class="dialog-footer">
											<el-button @click="dialogVisible1 = false">取 消</el-button>
											<el-button type="primary" @click="requestDirectionalPlan">确 定</el-button>
										</span>
									</el-dialog>
									<!--填写物流信息-->
									<el-dialog :visible.sync="dialogVisible3"  width="500px">
										<el-form :model="form3" :rules="rule3" ref="form3" class="form3">
											<el-form-item label="物流公司" label-width="80px" prop="logisticName">
												<el-select v-model="form3.logisticName" placeholder="请选择">
													  <el-option v-for="item in options" :key="item.value" :label="item.label" :value="item.value"> </el-option>
                                                </el-select>
											</el-form-item>
											<el-form-item label="物流编号" label-width="80px" prop="logisticNo">
												<el-input v-model="form3.logisticNo" auto-complete="off"></el-input>
											</el-form-item>
											<el-form-item label="邮费" label-width="80px" prop="postage">
												<el-input v-model="form3.postage" auto-complete="off"></el-input>
											</el-form-item>
										</el-form>
										<div slot="footer" class="dialog-footer">
											<el-button @click="dialogVisible3 = false">取 消</el-button>
											<el-button type="primary" @click="setLogisticsInfo">确 定</el-button>
										</div>
									</el-dialog>
									<!--卖点介绍-->
									<el-dialog :visible.sync="dialogVisible5" width="500px" class="dialog5">
									    <div class="digcontent">
										<p>1.卖点介绍1</p>
										<p>1.卖点介绍1</p>
										<p>1.卖点介绍1</p>
										<p>1.卖点介绍1</p>
										<p>1.卖点介绍1</p>
										<p>1.卖点介绍1</p>
										<p>1.卖点介绍1</p>
										<p>1.卖点介绍1</p>
										<p>1.卖点介绍1</p>
										<p>1.卖点介绍1</p>
										<p>1.卖点介绍1</p>
										<p>1.卖点介绍1</p>
										<p>1.卖点介绍1</p>
										<p>1.卖点介绍1</p>
										<p>1.卖点介绍1</p>
										<p>1.卖点介绍1</p>
										<p>1.卖点介绍1</p>
										<p>1.卖点介绍1</p>
										</div>
									</el-dialog>
								</div>
								<!--分页开始-->
								<div class="pagebox">
                                    <el-pagination @size-change="handleSizeChange" @current-change="handleCurrentChange" :current-page.sync="pageIndex" :page-size="itemsPerPage" layout="prev, pager, next, jumper" :total="total"></el-pagination>
							    </div>
							    <!--分页结束-->
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

<style>
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
	width:100px;
}
.titlebox > div.title5{
	width:100px;
}
.titlebox > div.title6{
	width:100px;
}
.titlebox > div.title7{
	width:120px;
}
.contentbox{
	margin-top:30px;
	position:relative;
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
	width:190px;
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
	height:140px;
	line-height:140px;
	float:left;
}
.bottombox .quan{
	width:100px;
	text-align:center;
	font-size:14px;
	height:140px;
	float:left;
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
	font-size:14px;
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
    font-size: 12px;
    margin-top:2px;
}
.pagebox{
	margin:30px auto;
	text-align:right;
}
/*.el-date-editor.el-input, .el-date-editor.el-input__inner{*/
	/*width:400px;*/
/*}*/
.planstate{
	position: absolute;
    right: 230px;
    width: 100px;
    top: 37px;
    bottom:42px;
    border-left: 1px solid #ebeef5;
    text-align: center;
}
.planstate .outer,.orderstate .outer,.option .outer{
	height:100%;
	width:100%;
	display:table;
}
.quan .outer{
	height:100%;
	width:100px;
	display:table;
}
.planstate .inner,.orderstate .inner,.option .inner,.quan .inner{
	height:100%;
	display:table-cell;
	vertical-align: middle;
}
.orderstate{
	position: absolute;
    right: 121px;
    width: 110px;
    top: 37px;
    bottom:42px;
    border-left: 1px solid #ebeef5;
    text-align: center;
}
.orderstate span{
	margin-top:60px;
	display:block;
}
.option{
	position: absolute;
    right:0px;
    width: 120px;
    top: 37px;
    bottom:42px;
    border-left: 1px solid #ebeef5;
    text-align: center;
}
.option button:first-child{
	margin-top:15px;
}
.option button{
    width:100%;
    padding:0;
    margin:0 0 10px 0;
    margin-left:0 !important;
	display:block;
}
.topbox>div.shop{
    padding-left: 25px;
    position: relative;
    width: 68px;
    overflow: hidden;
    text-overflow: ellipsis;
    white-space: nowrap;
    margin-left:150px;
}
.topbox>div.shop .icon{
    position: absolute;
    top: 6px;
    left:0px;
    width: 22px;
    height: 22px;
}
.topbox>div.shop .icon-tian{
    background: url(~assets/images/pro.png) -162px 0 no-repeat;
}
.topbox>div.shop .icon-tao{
    background: url(~assets/images/pro.png) -162px -28px no-repeat;
}
.form4 .el-rate{
	margin-left:80px;
}
.form4 .el-textarea{
   width:350px;
}
.form4 .el-textarea__inner{
	width:100%;
	height:80px !important;
}
.form3 .el-select{
	width:350px;
}
.form3 .el-input{
	width:350px;
}
.form .el-date-editor{
	width:300px !important;
}
.el-dialog__body{
	padding:20px !important;
}
.el-dialog__footer{
    text-align:center !important;
	border-top:1px solid #eee;
	padding:15px !important;
}
.sqdxdialog .el-dialog__body{
	padding: 20px 20px 40px 20px!important;
}
.pqtip{
	padding-left: 120px;
    color: red;
    margin-top: -12px;
}
.dialog5 .el-dialog__body{
	height:260px;
	overflow:auto;
}
.orderstate .inner.ycstate{
	color:red;
}
.orderstate .inner.ycstate .reason,.orderstate .inner.fhstate .wlnum{
	cursor:default;
}
.orderstate .inner.ycstate .reason span{
	margin-top: -3px;
    display: inline-block;
    font-size: 12px;
    width: 58px;
    overflow: hidden;
    text-overflow: ellipsis;
    white-space: nowrap;
    vertical-align: middle;
}
.orderstate .inner.wcstate{
	color:green;
}
.orderstate .inner.fhstate .wlnum span{
	margin-top: -3px;
    display: inline-block;
    font-size: 12px;
    vertical-align: middle;
}
.dxtip{
	text-align: center;
    margin-top: 10px;
    color: #000;
}
.dxtip a{
	color:#f84933;
}
.copybox{
	margin-top:0px;
    display: inline-block;
    font-size:12px;
    color:#f96d5c;
    cursor:pointer;
    padding:8px;
}
</style>
