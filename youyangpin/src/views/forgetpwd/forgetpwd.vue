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
				  <el-main class="maincon">
				    <p class="title">忘记密码</p>
				    <div class="content">
				        <div class="titlelist">
				           <ul> 
				              <li :class="{ 'active': active > 0  }"><span class="circle">1</span><span class="word">1.输入手机号</span></li>
				              <li :class="{ 'active': active > 1  }"><span class="circle">2</span><span class="word">2.验证身份</span></li>
				              <li :class="{ 'active': active > 2  }"><span class="circle">3</span><span class="word">3.设置新密码</span></li>
				              <li :class="{ 'active': active > 3  }"><span class="circle">4</span><span class="word">4.完成</span></li>
				           </ul>
				        </div>
	                    <!--1.输入手机号-->
	                    <div class="modifypsd registerbox  modifypsd1" v-show="active == 1">
	                         <el-form :model="ruleForm1"  :rules="rules1" ref="ruleForm1" label-width="100px">
							  <el-form-item label="手机号码" prop="mobilePhone" >
							    <el-input  v-model="ruleForm1.telphone" auto-complete="off"  placeholder="请输入手机号码"></el-input>
							  </el-form-item>
							  <el-form-item label="验证码" prop="yzCode">
							    <el-input  v-model="ruleForm1.imageIdentifyCode"  auto-complete="off"  placeholder="请输入图形验证码"  class="codetxt"></el-input>
								  <span class="imgbox" @click="getImgCode"><img :src="imgCode" class="logo"></span>
							  </el-form-item>
							  <el-form-item>
							    <el-button type="primary" @click="submitForm('ruleForm1',ruleForm1)">下一步</el-button>
							  </el-form-item>
							</el-form>	  
	                    </div>
	                    <!--2.验证身份-->
	                    <div class="modifypsd registerbox modifypsd2" v-show="active == 2">
	                         <el-form :model="ruleForm2"  :rules="rules2" ref="ruleForm2" label-width="100px">
	                           <el-form-item label="手机号码">
								  <span>{{ ruleForm1.telphone }}</span>
							   </el-form-item>
							   <el-form-item label="短信验证码" prop="mobileYzCode">
							    <el-input  v-model="ruleForm2.imageIdentifyCode"  auto-complete="off"  placeholder="请输入6位数字短信验证码"  class="codetxt"></el-input><el-button class="getcode" @click="getCode">获取验证码</el-button>
							   </el-form-item>
							   <el-form-item>
								    <el-button type="primary" @click="submitForm('ruleForm2',ruleForm2.imageIdentifyCode)">下一步</el-button>
							   </el-form-item>
							</el-form>
	                    </div>
	                    <!--3.设置新密码-->
	                    <div class="modifypsd registerbox modifypsd3" v-show="active == 3">
	                         <el-form :model="ruleForm3"  :rules="rules3" ref="ruleForm3" label-width="100px">
	                           <el-form-item label="设置密码" prop="pass">
							     <el-input type="password" v-model="ruleForm3.newPassword" auto-complete="off" placeholder="密码必须为6-25位数字 + 字母"></el-input>
							   </el-form-item>
							   <el-form-item label="确认密码" prop="checkPass">
							     <el-input type="password" v-model="ruleForm3.checkPass" auto-complete="off" placeholder="请再次输入密码"></el-input>
							   </el-form-item>
							   <el-form-item>
								    <el-button type="primary" @click="submitForm('ruleForm3',ruleForm3.newPassword)">下一步</el-button>
							   </el-form-item>
							</el-form>
	                    </div>
	                    <!--4.完成-->
	                    <div class="modifypsd registerbox modifypsd4" v-show="active == 4">
				 			<div class="tip">恭喜您,密码重置成功</div>
							<div class="link">您现在可以<router-link to="login">登录</router-link>或返回<router-link to="index">优样品首页</router-link></div>
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
    import forgetpwd from './forgetpwd'
    export default {
        ...forgetpwd
    }
</script>

<style scoped>
.maincon{
	background:#fff;
}
.maincon .title{
	font-size:18px;
	font-weight:bold;
	color:#f84933;
}
.modifypsd4{
	text-align:center;
	font-size:18px;
}
.modifypsd4 div{
	margin-bottom:15px;
}
.modifypsd4  a{
	color:#f84933;
}
.titlelist{
	height: 60px;
    width:710px;
    margin: 30px auto;
}
.titlelist li{
	float:left;
	position:relative;
	width:220px;
}
.titlelist li .circle{
	display:block;
	width:30px;
	height:30px;
	border:2px solid #eee;
	border-radius:100%;
	text-align:center;
	line-height:30px;
	color:#333;
}
.titlelist li:after{
	content: '';
    position: absolute;
    top: 18px;
    left: 34px;
    width: 185px;
    height: 2px;
    background: #eee;
}
.titlelist li:last-child{
	width:50px;
}
.titlelist li:last-child:after{
	width:0px;
}
.titlelist li.active .circle{
	color:#f84933;
	border-color:#f84933;
}
.titlelist li.active{
	color:#f84933;
	font-weight:bold;
}
.titlelist li .word{
    display:block;
	margin-left:-20px;
	margin-top:10px;
}
.titlelist li:last-child .word{
	margin-left:0;
}
.registerbox{
	width:500px;
	margin:0 auto;
	padding:40px 0;
}
.registerbox .title{
    text-align:right;
	margin-bottom:20px;
}
.registerbox .title a{
	color:#f95741;
}
.registerbox .codetxt{
	width:180px;
}
.registerbox .getcode{
	float:right;
	text-align:center;
	background:#f95741;
    color:#fff;
    border:none;
    width:100px;
    margin:0;
}
.registerbox .imgbox{
    display:block;
	float:right;
	height:40px;
	overflow:hidden;
	width:110px;
}
.registerbox .imgbox img{
	width:100%;
	height:100%;
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
	width:400px;
	padding:60px 0;
	margin:0 auto;
}
.modifypsd button{
    width: 150px;
    margin-left: 60px;
    margin-top: 30px;
}
</style>