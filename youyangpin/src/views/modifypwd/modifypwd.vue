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
				    <p class="title">修改密码</p>
				    <div class="content">
	                    <!--修改密码-->
	                    <div class="modifypsd modifybox">
	                         <el-form :model="ruleForm"  :rules="rules" ref="ruleForm" label-width="120px" >
							  <el-form-item label="验证原密码" prop="prepwd" >
							    <el-input type="password" auto-complete="off" v-model="ruleForm.prepwd" placeholder="密码为6-25位数字+字母"></el-input>
							  </el-form-item>
							  <el-form-item label="设置新密码" prop="newpwd" >
							    <el-input type="password" auto-complete="off" v-model="ruleForm.newpwd" placeholder="密码为6-25位数字+字母"></el-input>
							  </el-form-item>
							   <el-form-item label="新密码确认" prop="surepwd" >
							    <el-input type="password" auto-complete="off" v-model="ruleForm.surepwd" placeholder="密码为6-25位数字+字母"></el-input>
							  </el-form-item>
							  <el-form-item>
							    <el-button type="primary" @click="submitForm('ruleForm')">保&nbsp;存</el-button>
							  </el-form-item>
							</el-form>
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
    import modifypwd from './modifypwd'
    export default {
        ...modifypwd
    }
</script>

<style scoped>
.modifybox{
	width:430px !important;
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