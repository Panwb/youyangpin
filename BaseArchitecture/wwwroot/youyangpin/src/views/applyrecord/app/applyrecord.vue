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
                       <el-menu class="linklist" :default-active="asideIndex">
					      <el-menu-item index="1">
					        <span slot="title">我的订单</span>
					      </el-menu-item>
					      <el-menu-item index="2">
					        <span slot="title">申请记录</span>
					      </el-menu-item>
					      <el-menu-item index="3">
					        <span slot="title">运费提现</span>
					      </el-menu-item>
					      <el-menu-item index="4">
					        <span slot="title">个人信息</span>
					      </el-menu-item>
					       <el-menu-item index="5">
					        <span slot="title">修改密码</span>
					      </el-menu-item>
					    </el-menu>
				  </el-aside>
				  <el-main class="mainbox">
				    <p class="title">申请记录</p>
				    <div class="content">
				       <!--申请记录-->
				       <div class="myorder">
	                       <el-tabs v-model="activeName" @tab-click="handleClick">
						     <el-tab-pane label="所有记录" name="order1">
						         <template>
								     <div class="titlebox">
								        <div class="title1">宝贝</div>
								        <div class="title2">销量</div>
								        <div class="title3">库存</div>
								        <div class="title4">优惠方式</div>
								        <div class="title5">是否需要退样</div>
								        <div class="title6">审核状态</div>
								     </div>
								     <div class="contentbox">
								         <div class="topbox">
								            <div class="date">2017-09-08</div>
								         
								            <div class="shop"><img src="../../../assets/images/hamburger.png">蕾蕾旗舰店</div>
								            <div  class="wechat">微信:1111</div>
								            <div class="phone">联系电话:17336532546</div>
								         </div>
								         <div class="bottombox clear">
								            <div class="infobox">
								               <div class="imgbox"><img src="../../../assets/images/hamburger.png"></div>
								               <div class="con">
								                 <p class="name">2018春季新款大V领荷叶边长袖小心机雪纺阿达</p> 
								                 <p class="price">直播专享价:<span class="num">168.00</span> <span class="normal">日常价:198.00</span></p> 
								                 <p class="money">佣金比例:<span class="num">10</span></p>
								                 <p class="detail">提供多色（3种颜色)</p>
								                 <p class="date">需要退回样品</p>
								               </div>
								            </div>
								            <div class="salenum">1111</div>
								            <div class="leavenum">501</div>
								            <div class="quan">30元优惠券</div>
								            <div class="orderstate"><span>是</span></div>
								            <div class="option">
								             <div>
                                                  <span class="passno">待审核</span>
                                                  <span class="passsuccess">审核通过</span>
                                                  <span class="passfail">审核不通过</span>
								             </div>
								         </div>
								        </div>
								     </div>
								     <div class="contentbox contentbox2">
								         <div class="topbox">
								            <div class="date">2017-09-08</div>
								            <div class="shop"><img src="../../../assets/images/hamburger.png">蕾蕾旗舰店</div>
								            <div  class="wechat">微信:1111</div>
								            <div class="phone">联系电话:17336532546</div>
								         </div>
								         <div class="bottombox clear bottombox1">
								            <div class="infobox">
								               <div class="imgbox"><img src="../../../assets/images/hamburger.png"></div>
								               <div class="con">
								                 <p class="name">2018春季新款大V领荷叶边长袖小心机雪纺阿达</p> 
								                 <p class="price">直播专享价:<span class="num">168.00</span> <span class="normal">日常价:198.00</span></p> 
								                 <p class="money">佣金比例:<span class="num">10</span></p>
								                 <p class="detail">提供多色（3种颜色)</p>
								                 <p class="date">需要退回样品</p>
								               </div>
								            </div>
								            <div class="salenum">1111</div>
								            <div class="leavenum">501</div>
								            <div class="quan">30元优惠券</div>
								            <div class="orderstate"><span>是</span></div>
								            <div class="option">
                    
								            </div>
								         </div>
								         <div class="bottombox clear bottombox2">
								            <div class="infobox">
								               <div class="imgbox"><img src="../../../assets/images/hamburger.png"></div>
								               <div class="con">
								                 <p class="name">2018春季新款大V领荷叶边长袖小心机雪纺阿达</p> 
								                 <p class="price">直播专享价:<span class="num">168.00</span> <span class="normal">日常价:198.00</span></p> 
								                 <p class="money">佣金比例:<span class="num">10</span></p>
								                 <p class="detail">提供多色（3种颜色)</p>
								                 <p class="date">需要退回样品</p>
								               </div>
								            </div>
								            <div class="salenum">1111</div>
								            <div class="leavenum">501</div>
								            <div class="quan">30元优惠券</div>
								            <div class="orderstate"><span>是</span></div>
								            <div class="option">
								              <div>
                                                  <span class="passno">待审核</span>
                                                  <span class="passsuccess">审核通过</span>
                                                  <span class="passfail">审核不通过</span>
								              </div>
								         </div>
								         </div>
								     </div>
								      <div class="pagebox">
									    <el-pagination @size-change="handleSizeChange" @current-change="handleCurrentChange":current-page.sync="currentPage1":page-size="100" layout="prev, pager, next, jumper" :total="1000">
							            </el-pagination>
									  </div>
								  </template>
							  </el-tab-pane>
						      <el-tab-pane label="待审核" name="order2"></el-tab-pane>
						      <el-tab-pane label="审核通过" name="order3"></el-tab-pane>
						      <el-tab-pane label="审核不通过" name="order4"></el-tab-pane>
					       </el-tabs>
					      
							
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
      asideIndex: '2',
      textarea: '',
      value: null,
      activeName: 'order1',
      dialogVisible1: false,
      dialogVisible2: false,
      dialogVisible3: false,
      dialogVisible4: false,
      activeIndex: '2',
       form: {
          date: ''
       },
       form3: {
          companyName:'',
          wuliuid:'',
          money:''
       },
       form4: {
          textarea:''
       }
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
	width:180px;
}
.titlebox > div.title6{
	width:170px;
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
	margin-left:25px;
	color:#666;
}
.topbox > div.shop img{
	width: 15px;
    height: 15px;
    vertical-align: middle;
    margin-right: 5px;
}
.topbox > div.wechat{
	margin-left:180px;
}
.topbox > div.phone{
	margin-left:180px;
	color:#000;
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
.bottombox .orderstate{
   width:180px;
 }
.bottombox .option{
	border-left:1px solid #ebeef5;
}
.bottombox .option span:first-child{
	margin-top:20px;
}
.bottombox .option .passno{
	
}
.bottombox .option .passfail{
	color:red;
}
.bottombox .option .passsuccess{
	color:green;
}
.bottombox .option span{
	display:block;
	text-align:center;
	margin-bottom:10px;
}
.bottombox .option{
	float:left;
	width:160px;
	text-align:center;
	height:110px;
	padding:15px 0;
	border-bottom: 1px solid #ebeef5;
}
.contentbox2 .bottombox1 .option{
	border-bottom:none;
}
.contentbox2 .bottombox2{
	border-bottom: 1px solid #ebeef5;
}
.contentbox2 .bottombox2 .salenum,.contentbox2 .bottombox2 .leavenum,.contentbox2 .bottombox2 .quan,.contentbox2 .bottombox2 .infobox{
	border:none
}

.contentbox2 .bottombox2 .option div{
	margin-top:-70px;
}
.bottombox .option button{
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
</style>