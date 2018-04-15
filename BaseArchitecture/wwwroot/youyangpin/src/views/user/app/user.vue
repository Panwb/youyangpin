<template>
  <div id="app">  
	<el-container>
      <!--header start--->
       <div class="optbox">
          <div class="wd1200">      
			  <span class="loginbtn">请登录</span>
			  <span>免费注册</span>
          </div>
         </el-header>
      </div>
      <div class="wd1200 searchbox">
	      <el-row>
			  <el-col :span="8"><div class="grid-content bg-purple"> <img src="../../../assets/images/logo.png" class="logo"></div></el-col>
			  <el-col :span="16">
			   <div class="grid-content bg-purple-light seabox">
			     <el-input placeholder="关键词搜索" prefix-icon="el-icon-search"></el-input>
			     <el-button class="sea-btn">搜索</el-button>
			   </div>
			  </el-col>
		  </el-row>
      </div>
      <div class="navbox">
		  <el-header>
		     <div class="wd1200">
		      <el-menu :default-active="activeIndex"  class="el-menu-demo" mode="horizontal" @select="handleSelect" background-color="#261f1e" text-color="#fff" active-text-color="#f9513b">
				  <el-menu-item index="1">首页</el-menu-item>
				  <el-menu-item index="2">日常产品</el-menu-item>
				  <el-menu-item index="3">秒杀产品</el-menu-item>
				  <el-menu-item index="4">新款产品</el-menu-item>
				  <el-menu-item index="5">清仓产品</el-menu-item>
				  <el-menu-item index="6">高端产品</el-menu-item>
			  </el-menu>
			 </div>
		  </el-header>
	  </div>
	  <!--header end--->

      <!--main start--->
	  <el-main class="maincontent">
	    <div class="wd1200">
             <el-container>
				  <el-aside class="asidebox">
				       <p class="title">个人中心</p>
                       <el-menu class="linklist">
					      <el-menu-item index="1">
					        <span slot="title">我的订单</span>
					      </el-menu-item>
					      <el-menu-item index="2">
					        <span slot="title">运费申请</span>
					      </el-menu-item>
					      <el-submenu index="3">
					        <template slot="title">账号管理</template>
					        <el-menu-item-group>
					          <el-menu-item index="3-1">个人信息</el-menu-item>
					          <el-menu-item index="3-2">修改密码</el-menu-item>
					        </el-menu-item-group>
					      </el-submenu>
					      <el-menu-item index="4">
					        <span slot="title">服务协议</span>
					      </el-menu-item>
					    </el-menu>
				  </el-aside>
				  <el-main class="mainbox">
				  <router-view/>
				    <p class="title">我的订单</p>
				    <div class="content">
				       <!--我的订单-->
				       <div class="myorder">
	                       <el-tabs v-model="activeName" @tab-click="handleClick">
						     <el-tab-pane label="所有订单" name="order1">
						         <template>
								    <el-table :data="tableData">
								      <el-table-column prop="shopname" label="店铺名" width="80"></el-table-column>
								      <el-table-column prop="userid" label="旺旺号" width="100"></el-table-column>
								      <el-table-column prop="userphone" label="联系人电话" width="110"></el-table-column>
								      <el-table-column prop="orderid" label="订单号" width="110"></el-table-column>
								      <el-table-column prop="orderstate" label="订单状态" width="110"></el-table-column>
								      <el-table-column prop="planstate" label="定向计划状态" width="110"></el-table-column>
								      <el-table-column prop="shopinfo" label="商品信息"></el-table-column>
								      <el-table-column prop="option" label="操作" width="110"></el-table-column>
								    </el-table>
								  </template>
							  </el-tab-pane>
						      <el-tab-pane label="待发货" name="order2"></el-tab-pane>
						      <el-tab-pane label="已发货" name="order3"></el-tab-pane>
						      <el-tab-pane label="待退货" name="order5"></el-tab-pane>
						      <el-tab-pane label="已退货" name="order6">已退货</el-tab-pane>
						      <el-tab-pane label="待退费" name="order7">待退费</el-tab-pane>
						      <el-tab-pane label="已退费" name="order8">已退费</el-tab-pane>
						      <el-tab-pane label="已完成" name="order9">已完成</el-tab-pane>
						      <el-tab-pane label="异常订单" name="order10">异常订单</el-tab-pane>
						      <el-tab-pane label="异常订单" name="order10">异常订单</el-tab-pane>
					       </el-tabs>
                       </div>
                       <!--运费申请-->
					   <div class="applybox">
	                        <div class="zfbbox">您的支付宝账号：<span class="zfid">111</span></div> 
	                        <div class="moneybox">当前可提现金额：<span class="num">100元</span></div>
	                        <div class="btnbox"><el-button class="applybtn" disabled>申请提现</el-button></div>
	                        <div class="tipbox">（*单次提现金额需超过100元）</div>
	                    </div>
	                    <!--修改密码-->
	                    <div class="modifypsd">
	                         <el-form label-width="120px" >
							  <el-form-item label="*验证原密码：" >
							    <el-input type="age" auto-complete="off"></el-input>
							  </el-form-item>
							  <el-form-item label="*设置新密码：" >
							    <el-input type="age" auto-complete="off"></el-input>
							  </el-form-item>
							  <el-form-item>
							    <el-button type="primary">保存</el-button>
							  </el-form-item>
							</el-form>
	                    </div>
				    </div>
				  </el-main>
			  </el-container>
	    </div>
	  </el-main>
	  <!--main end--->

	  <!--footer start--->
	  <el-footer>
	     <div class="wd1200">
		     <ul class="linklist">
		        <li><a a href="https://www.ele.me" target="_blank">淘宝网</a></li>
		        <li><a a href="https://www.ele.me" target="_blank">天猫</a></li>
		        <li><a a href="https://www.ele.me" target="_blank">聚划算</a></li>
		        <li><a a href="https://www.ele.me" target="_blank">全球速实通</a></li>
		        <li><a a href="https://www.ele.me" target="_blank">阿里巴巴国际交易市场</a></li>
		        <li><a a href="https://www.ele.me" target="_blank">1688</a></li>
		        <li><a a href="https://www.ele.me" target="_blank">阿里妈妈</a></li>
		     </ul>
		     <p class="copyright">©copyright 2016-2018 优样品 www.youyangpin.com.<a href="http://www.beianbeian.com/beianxinxi/a40cc71f-db17-4d78-80dd-4b232dab5880.html">粤ICP备15114843号-1</a></p>
         </div>
	  </el-footer>
	  <!--footer end--->
	</el-container>
  </div>
</template>

<script>
import mainHeader from '../../../components/header.vue'
import mainFooter from '../../../components/footer.vue'

export default {
  data () {
    return {
      activeName: 'order1',
      tableData: [{
            shopname: '王小二的店铺',
            userid: 'cutemantou',
            userphone: '18825815552',
            orderid:'123456',
            orderstate:'已完成',
            planstate:'开始执行',
            shopinfo:"商品信息",
            option:"操作"
          }]
    }
  },
  methods: {
	handleSelect(key, keyPath) {
	  console.log(key, keyPath);
	},
	handleClick(tab, event) {
      console.log(tab, event);
    }
  }
}
</script>
<style>
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
}
.mainbox .content .el-tabs__header{
	padding:0 15px;
}
.mainbox .content .el-tabs__content{
	padding:0 15px;
}
.mainbox .el-table__header-wrapper table{
	width:100% !important;
}
.applybox{
   width:300px;
   padding:50px 0;
   margin:0 auto;
}
.applybox div{
	margin-bottom:15px;
}
.applybox .moneybox .num{
	color:red;
}
.applybox .applybtn{
	background:#ccc;
	color:#fff;
	border:none;
	padding:10px 20px;
}
.applybox .applybtn.active{
	background:#f9513b;
}
.applybox .tipbox{
	font-size:12px;
	color:#f9513b;
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
.modifypsd{
	width:500px;
	padding:50px 0;
	margin:0 auto;
}
</style>