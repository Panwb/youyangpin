
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
				    <p class="title">个人信息</p>
				    <div class="content">
	                    <!--个人信息-->
	                    <div class="modifypsd">
	                       <el-form :model="ruleForm"  :rules="rules" ref="ruleForm" label-width="100px">
							  <el-form-item label="主播名称" prop="userName" >
							    <el-input v-model="ruleForm.userName" auto-complete="off"></el-input>
							  </el-form-item>
							  <el-form-item label="支付宝账号" prop="zhifuId" >
							    <el-input v-model="ruleForm.zhifuId" auto-complete="off"></el-input>
							  </el-form-item>
							   <el-form-item label="身高" prop="height" class="linebox">
							    <el-input v-model="ruleForm.height" auto-complete="off" placeholder="CM"></el-input>
							  </el-form-item>
							  <el-form-item label="体重" prop="weight" class="linebox">
							    <el-input v-model="ruleForm.weight" auto-complete="off" placeholder="KG"></el-input>
							  </el-form-item>
							  <el-form-item label="鞋码" prop="shoeSize" class="linebox">
							    <el-input v-model="ruleForm.shoeSize" auto-complete="off" placeholder="码数"></el-input>
							  </el-form-item>
							  <el-form-item label="尺码" prop="size"  class="linebox">
							   <el-select v-model="ruleForm.size" placeholder="请选择">
							      <el-option label="S" value="S"></el-option>
                                  <el-option label="M" value="M"></el-option>
                                  <el-option label="L" value="L"></el-option>
                                  <el-option label="XL" value="XL"></el-option>
                                  <el-option label="XXL" value="XXL"></el-option>
                                  <el-option label="XXXL" value="XXXL"></el-option>
                                  <el-option label="XXXXL" value="XXXXL"></el-option>
							   </el-select>
							  </el-form-item>
							  <el-form-item label="收货地址" prop="address" class="addressbox">
							    <el-input :autosize="{ minRows:3, maxRows: 6}" type="textarea" v-model="ruleForm.address"></el-input>
							  </el-form-item>
							  <el-form-item label="收货人姓名" prop="linkName" >
							    <el-input v-model="ruleForm.linkName" auto-complete="off"></el-input>
							  </el-form-item>
							  <el-form-item label="收货人电话" prop="linkPhone" >
							    <el-input v-model="ruleForm.linkPhone" auto-complete="off"></el-input>
							  </el-form-item>
							  <el-form-item label="淘客名称" prop="tkName" >
							    <el-input v-model="ruleForm.tkName" auto-complete="off"></el-input>
							  </el-form-item>
							  <el-form-item label="微信" prop="wechatId" >
							    <el-input v-model="ruleForm.wechatId" auto-complete="off"></el-input>
							  </el-form-item>
							  <el-form-item label="QQ" prop="qqId" >
							    <el-input v-model="ruleForm.qqId" auto-complete="off"></el-input>
							  </el-form-item>
							  <el-form-item label="垂直领域" prop="type">
							    <el-checkbox-group v-model="ruleForm.type">
							      <el-checkbox label="美搭" name="type1"></el-checkbox>
							      <el-checkbox label="美妆个护" name="type2"></el-checkbox>
							      <el-checkbox label="居家" name="type3"></el-checkbox>
							      <el-checkbox label="美食" name="type4"></el-checkbox>
							      <el-checkbox label="母婴" name="type5"></el-checkbox>
							      <el-checkbox label="型男" name="type6"></el-checkbox>
							      <el-checkbox label="其他" name="type7"></el-checkbox>
							    </el-checkbox-group>
							  </el-form-item>
							  <el-form-item label="每天开播时段"  >
							    <el-time-select  class="time" placeholder="起始时间" v-model="ruleForm.startTime" :picker-options="{ start: '08:30',step: '00:15',end: '18:30'}">
								</el-time-select>
								<span class="line"></span>
								<el-time-select  class="time" placeholder="结束时间" v-model="ruleForm.endTime"
								    :picker-options="{
								      start: '08:30',
								      step: '00:15',
								      end: '18:30',
								      minTime: startTime
								    }">
								  </el-time-select>
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
	var validateuserName = (rule, value, callback) => {
	    if (value === '') {
	      callback(new Error('请输入主播名称'));
	    }else {
	      callback();
	    }
	};
	var validateuserzhifuId= (rule, value, callback) => {
	    if (value === '') {
	      callback(new Error('请输入支付宝账号'));
	    }else {
	      callback();
	    }
	};
	var validateheight= (rule, value, callback) => {
	    if (value === '') {
	      callback(new Error('请输入身高'));
	    }else {
	      callback();
	    }
	};
	var validateweight= (rule, value, callback) => {
	    if (value === '') {
	      callback(new Error('请输入体重'));
	    }else {
	      callback();
	    }
	};
	var validateshoeSize= (rule, value, callback) => {
	    if (value === '') {
	      callback(new Error('请输入鞋码'));
	    }else {
	      callback();
	    }
	};
	var validateaddress= (rule, value, callback) => {
	    if (value === '') {
	      callback(new Error('请输入收货地址'));
	    }else {
	      callback();
	    }
	};
	var validatelinkName= (rule, value, callback) => {
	    if (value === '') {
	      callback(new Error('请输入联系人姓名'));
	    }else {
	      callback();
	    }
	};
	var validatelinkPhone= (rule, value, callback) => {
	    if (value === '') {
	      callback(new Error('请输入联系人电话'));
	    }else {
	      callback();
	    }
	};
	var validateqqId= (rule, value, callback) => {
	    var qqreg=/[1-9]\\d{4,14}/;  
	    if (!qqreg.test(value)) {
	      callback(new Error('qq号码格式不正确'));
	    }else {
	      callback();
	    }
	};

    return {
      asideIndex:'4',
      ruleForm: {
          userName: '',
          zhifuId:'',
          height:'',
          weight:'',
          size:'',
          shoeSize:'',
          address:'',
          linkName:'',
          linkPhone:'',
          tkName:'',
          type: [],
          qqId:'',
          startTime: '',
          endTime: ''
        },
        rules: {
          userName: [
            { required: true, validator: validateuserName, trigger: 'blur' }
          ],
          zhifuId: [
            { required: true, validator: validateuserzhifuId, trigger: 'blur' }
          ],
          height: [
            { required: true, validator: validateheight, trigger: 'blur' }
          ],
          weight: [
            { required: true, validator: validateweight, trigger: 'blur' }
          ],
          shoeSize: [
            { required: true, validator: validateshoeSize, trigger: 'blur' }
          ],
          address: [
            { required: true, validator: validateaddress, trigger: 'blur' }
          ],
          linkName: [
            { required: true, validator: validatelinkName, trigger: 'blur' }
          ],
          linkPhone: [
            { required: true, validator: validatelinkPhone, trigger: 'blur' }
          ],
          qqId: [
            { validator: validateqqId, trigger: 'blur' }
          ],
          type: [
            { type: 'array', required: true, message: '请至少选择一个垂直领域', trigger: 'change' }
          ]
      }
     }
  },
  methods: {
	handleSelect(key, keyPath) {
	  console.log(key, keyPath);
	},
	handleClick(tab, event) {
      console.log(tab, event);
    },
    submitForm(formName) {
      this.$refs[formName].validate((valid) => {
        if (valid) {
          alert('submit!');
        } else {
          console.log('error submit!!');
          return false;
        }
      });
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
	padding:40px;
	margin:0 auto;
}
.modifypsd .el-form{
	overflow:hidden;
}
.modifypsd .el-form-item{
	margin-bottom:15px;
}
.modifypsd .el-input{
    width:300px;
	height:35px;
	line-height:35px;
	width:300px;
}
.modifypsd .el-input.time{
	width:120px;
}
.modifypsd .el-textarea{
	width:610px;
}
.modifypsd .el-input .el-input__inner{
	height:35px;
	line-height:35px;
}
.modifypsd .el-form-item__content{
	line-height:35px;
}
.el-form-item__error{
    padding-top:0;
}
.el-form-item.desc .el-form-item__label,.el-form-item.range .el-form-item__label{
	line-height:20px;
}
.linebox{
	width:170px;
	float:left;
}
.linebox .el-input{
	width:100px;
}
.addressbox{
	clear:both;
}
.el-form-item__label{
	line-height:35px;
}
.line{
	display: inline-block;
    width: 10px;
    padding: 0 8px;
    height: 1px;
    background: #ddd;
    vertical-align: middle;
}
</style>