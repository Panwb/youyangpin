<template>
  <div id="app">  
	<el-container>
    <!-- header start -->
      <div class="wd1200 searchbox">
	      <el-row>
			  <el-col :span="8"><div class="grid-content bg-purple">
          <router-link to="/index"><img src="~assets/images/logo.png" class="logo"></router-link></div></el-col>
		    </el-row>
      </div>
	  <!-- header end -->

      <!-- main start -->
	  <el-main class="maincontent">
	    <div class="wd1000 registerbox loginbox">
        <el-row>
          <el-col :span="12">
            <div class="grid-content bg-purple"> 
              <img src="~assets/images/login.jpg" class="login">
              <div class="line"></div>
            </div>
          </el-col>
          <el-col :span="12">  
           <div class="logininbox">
            <p class="titlename">欢迎登录</p>
            <el-form :model="ruleForm2"  :rules="rules2" ref="ruleForm2" label-width="100px" class="demo-ruleForm">
              <el-form-item label="手机号码" prop="accountName" >
                <el-input  v-model="ruleForm2.accountName" auto-complete="off"  placeholder="请输入手机号码"></el-input>
              </el-form-item>
              <el-form-item label="密码" prop="password">
                <el-input type="password" v-model="ruleForm2.password" auto-complete="off" placeholder="密码必须为6-25位数字 + 字母"></el-input>
              </el-form-item>
              <el-form-item label="验证码" prop="identifyCode">
                <el-input  v-model="ruleForm2.identifyCode"  auto-complete="off"  placeholder="请输入图形验证码"  class="codetxt"></el-input>
                <span class="imgbox">
                  <img :src="imgCode" class="logo" @click="getImgCode">
                </span>
              </el-form-item>
              <el-form-item>
                <p class="forgetpwd"><router-link to="/forgetpwd">忘记密码</router-link></p>
                <el-button type="primary" @click="submitForm('ruleForm2')">登录</el-button>
              </el-form-item>
             </el-form>  
             <p class="title"><span class="login">还不是优样品用户?<router-link to="/register">30秒快速注册</router-link></span></p>
            </div>  
          </el-col>
        </el-row>
	        
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
  import login from './login'
  export default {
    ...login
  }
</script>

<style scoped>
.forgetpwd{
  text-align:right;
  margin-right:60px;
  
}
.forgetpwd a{
  color: #f95741;
}
.wd1000{
  width:1000px;
  margin:0 auto;
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
  cursor: pointer;
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
	background:#fff;
	min-height:500px;
  border-top:2px solid #dcdfe6;
}
.maincontent .wd1200{
	height:auto;
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
	width:280px;
}
.registerbox .getcode{
	float:right;
	text-align:center;
	background:#f95741;
    color:#fff;
    border:none;
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
.loginbox{
  width:1000px;
}
.loginbox .login{
  width:400px;
  margin-top:12px;
}
.logininbox{
  width:400px;
  border:1px solid #dcdfe6;
  position:relative;
  padding:20px 0;
}
.logininbox .titlename{
  color: #f84933;
  font-size: 18px;
  padding-left: 20px;
  margin-bottom: 20px;
}
.logininbox .title{
   padding-right: 98px;
   color: #666;
   margin:0;
}
.logininbox .el-input{
  width:250px;
}
.logininbox .codetxt{
  float:left;
  width:150px;
  margin-right:15px;
}
.logininbox .imgbox{
  width:85px;
  float:left;
}
.logininbox button{
  width:250px;
}
.loginbox .line{
  position:absolute;
  top:0;
  left:450px;
  height:352px;
  width:1px;
  background:#dcdfe6;
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