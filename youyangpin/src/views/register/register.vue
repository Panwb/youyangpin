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
	    <div class="wd1200 registerbox regbox">
           <p class="title">用户注册<span class="login">已有账号?<router-link to="/login">点击登录</router-link></span></p>
			<el-form :model="ruleForm2"  :rules="rules2" ref="ruleForm2" label-width="100px">
			  <el-form-item label="主播名称" prop="studioHostName">
			    <el-input  v-model="ruleForm2.studioHostName" auto-complete="off"  placeholder="请输入主播名称"></el-input>
			  </el-form-item>
			  <el-form-item label="账号" prop="telphone" >
			    <el-input  v-model="ruleForm2.telphone" auto-complete="off"  placeholder="请输入手机号码"></el-input>
			  </el-form-item>
			  <el-form-item label="验证码" prop="ImageIdentifyCode">
			    <el-input  v-model="ruleForm2.ImageIdentifyCode"  auto-complete="off"  placeholder="请输入图形验证码"  class="codetxt"></el-input>
				  <span class="imgbox"><img :src="imgCode" class="logo" @click="getImgCode"></span>
			  </el-form-item>
			  <el-form-item label="短信验证码" prop="SmsIdentifyCode">
			    <el-input  v-model="ruleForm2.SmsIdentifyCode"  auto-complete="off"  placeholder="请输入短信验证码"  class="codetxt"></el-input><el-button class="getcode" @click="getCode">获取验证码</el-button>
			  </el-form-item>
			  <el-form-item label="设置密码" prop="password">
			    <el-input type="password" v-model="ruleForm2.password" auto-complete="off" placeholder="密码必须为6-25位数字 + 字母"></el-input>
			  </el-form-item>
			  <el-form-item label="确认密码" prop="checkPass">
			    <el-input type="password" v-model="ruleForm2.checkPass" auto-complete="off" placeholder="请再次输入密码"></el-input>
			  </el-form-item>
			  <el-form-item>
			    <el-button type="primary" @click="submitForm('ruleForm2')" class="registerbtn">立即注册</el-button>
			  </el-form-item>
			</el-form>	  
	    </div>
	  </el-main>
	  <!-- main end -->

	  <!-- footer start -->
	  <el-footer>
      <main-footer></main-footer>
	  </el-footer>
	  <!-- footer end -->

    <el-dialog title="优样品-用户注册须知" :visible.sync="dialogVisible" width="40%"
    :before-close="handleClose" class="regisbox" :close-on-click-modal="false">
    <div class="dgcontent">
       <p>1.好单库面向各大招商淘客，暂不支持商家入驻，商家请联系淘客合作放单，请认真阅读和遵守以下规则。</p>
       <p>2.认真填写您的团队名号，名号代表着平台和别人对你的认可和信任，相当于您的身份证，请用您对外宣传和交流的名号进行注册。
         <span class="tip">（严禁使用他人或知名团队名号，除非是该团队创始人，严禁盗用名号）</span> </p>
       <p>3.联系QQ必须填写经常使用的大号，小号不审核不通过，并且保证单子出问题，能第一时间出面处理，严重伤害淘客利益的封号处理。</p>
       <p>4.连续30天没有发布单子或多次发布的单子被举报的已认证用户，将会自动取消认证，严重者封号并加入黑名单。</p>
       <p>5.平台对单子归属人和招商比较给力的个人或者团队进行排名榜推荐，请珍惜你的名号。发现乱用名号者，加入黑名单，拒绝注册。</p>
        <p>6.放单后台实行自主认证，为新用户提供新人专享的“新人专享认证礼包”，充值598元领取礼包可自主认证通过并获得发布积分。 已开放邀请好友注册功能，邀请6个好友并认证通过，可获得认证资格以及3000发布积分，邀请10个以上加送2万发布积分。</p>
       <p class="agree"><el-checkbox v-model="isRead" name="type1"></el-checkbox>已认真阅读并同意须知内容</p>
    </div>
    <span slot="footer" class="dialog-footer">
      <el-button type="primary" @click="dialogVisible = false"  :disabled="!isRead">确 定</el-button>
    </span>
  </el-dialog>
	</el-container>
  </div>
</template>

<script type="text/babel">
  import register from './register'
  export default {
    ...register
  }
</script>

<style>
.regbox{
    min-height:615px  !important;
	width:500px !important;
}
.regisbox .el-dialog__header{
  text-align:center;
  border-bottom:1px solid #eee;
}
.regisbox .el-dialog__footer{
  border-top:1px solid #eee;
  text-align:center;
}
.regisbox .el-dialog__header .el-dialog__close{
	display:none;
}
.el-dialog__header .el-dialog__title{
  color: #dd514c !important;
}
.dgcontent .el-checkbox{
   margin-right:5px;
}
.dgcontent p{
   line-height:30px;
}
.dgcontent p.agree{
   margin-top:10px;
   color:#000;
}
.dgcontent p .tip{
   color: #F37B1D;
}
.el-dialog__footer{
  text-align:center;
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
	min-height:698px;
	border-top: 2px solid #dcdfe6;
}
.maincontent .wd1200{
	height:auto;
}
.registerbox{
	margin:0 auto;
	padding:40px 0;
}
.registerbox .title{
	margin-bottom:20px;
  font-size:22px;
  padding-left:40px;
}
.registerbox .title span{
  float:right;
  font-size:14px;
  margin-top:10px;
}
.registerbox .title a{
	color:#f95741;
	text-decoration:underline;
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
.registerbtn{
	width:100%;
}
</style>