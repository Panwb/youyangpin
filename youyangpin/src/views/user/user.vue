
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
							<p class="title">个人信息</p>
							<div class="content">
								<!--个人信息-->
								<div class="modifypsd personinfo">
									<el-form :model="ruleForm" :rules="rules" ref="ruleForm" label-width="110px">
									    <!--<el-form-item label="账号状态" >
											<div v-if="ruleForm.CheckStatus === '待审核'" class="accountstate stateno">{{ ruleForm.CheckStatus }}</div>
											<div v-if="ruleForm.CheckStatus === '审核通过'" class="accountstate statesuccess">{{ ruleForm.CheckStatus }}</div>
											<div v-if="ruleForm.CheckStatus === '审核不通过'" class="accountstate statefail">{{ ruleForm.CheckStatus }}</div>
										</el-form-item>-->
										<el-form-item label="主播名称" prop="StudioHostName" >
											 <span class="zbname">{{ruleForm.StudioHostName}}</span>
											 <span class="shstate">
											    <i class="el-icon-error" v-if="ruleForm.CheckStatus === '审核不通过'" :title="'审核不通过原因：' + ruleForm.CheckFailReason"></i>
											    <i class="el-icon-success" v-if="ruleForm.CheckStatus === '审核通过'" title="审核通过"></i>
											  </span>
										</el-form-item>
										<!--<el-form-item label="支付宝账号" prop="AlipayAccount" >
											<el-input v-model="ruleForm.AlipayAccount" auto-complete="off"></el-input>
										</el-form-item>-->
										<el-form-item label="身高" prop="Height" class="linebox">
											<el-input v-model="ruleForm.Height" auto-complete="off" placeholder="CM" onkeypress="return event.keyCode>=48&&event.keyCode<=57" :maxlength="3"></el-input>
										</el-form-item>
										<el-form-item label="体重" prop="Weight" class="linebox">
											<el-input v-model="ruleForm.Weight" auto-complete="off" placeholder="KG" onkeypress="return event.keyCode>=48&&event.keyCode<=57" :maxlength="3"></el-input>
										</el-form-item>
										<el-form-item label="鞋码" prop="ShoeSize" class="linebox">
											<el-input v-model="ruleForm.ShoeSize" auto-complete="off" placeholder="码数" onkeypress="return event.keyCode>=48&&event.keyCode<=57" :maxlength="3"></el-input>
										</el-form-item>
										<el-form-item label="尺码" prop="ClothesSize"  class="linebox">
											<el-select v-model="ruleForm.ClothesSize" placeholder="请选择">
												<el-option label="S" value="S"></el-option>
												<el-option label="M" value="M"></el-option>
												<el-option label="L" value="L"></el-option>
												<el-option label="XL" value="XL"></el-option>
												<el-option label="XXL" value="XXL"></el-option>
												<el-option label="XXXL" value="XXXL"></el-option>
												<el-option label="XXXXL" value="XXXXL"></el-option>
											</el-select>
										</el-form-item>
										<el-form-item label="收货地址" prop="Address" class="addressbox">
											<el-input :autosize="{ minRows:3, maxRows: 6}" type="textarea" v-model="ruleForm.Address"></el-input>
										</el-form-item>
										<el-form-item label="收货人姓名" prop="LinkmanName" >
											<el-input v-model="ruleForm.LinkmanName" auto-complete="off"></el-input>
										</el-form-item>
										<el-form-item label="收货人电话" prop="LinkmanPhone" >
											<el-input v-model="ruleForm.LinkmanPhone" auto-complete="off"></el-input>
										</el-form-item>
										<el-form-item label="淘客名称" prop="TKName" >
											<el-input v-model="ruleForm.TKName" auto-complete="off"></el-input>
										</el-form-item>
										<el-form-item label="微信" prop="WeChat" >
											<el-input v-model="ruleForm.WeChat" auto-complete="off"></el-input>
										</el-form-item>
										<el-form-item label="QQ" prop="qqId" >
											<el-input v-model="ruleForm.QQ" auto-complete="off"></el-input>
										</el-form-item>
										<!--<el-form-item label="垂直领域" prop="type" v-if="isShowCheck">
											<el-checkbox-group v-model="ruleForm.VerticalFieldCode">
												<el-checkbox label="美搭" name="type1"></el-checkbox>
												<el-checkbox label="美妆个护" name="type2"></el-checkbox>
												<el-checkbox label="居家" name="type3"></el-checkbox>
												<el-checkbox label="美食" name="type4"></el-checkbox>
												<el-checkbox label="母婴" name="type5"></el-checkbox>
												<el-checkbox label="型男" name="type6"></el-checkbox>
												<el-checkbox label="其他" name="type7"></el-checkbox>
											</el-checkbox-group>
										</el-form-item>-->
                                        <div class="time-div">
                                            <el-form-item label="每天开播时段" prop="DailyBeginTime">
                                                <el-time-select
                                                        placeholder="起始时间"
                                                        v-model="ruleForm.DailyBeginTime"
                                                        :picker-options="{ start: '00:00',step: '01:00',end: '23:00'}">
                                                </el-time-select>
                                            </el-form-item>
                                            <el-form-item label="" prop="DailyEndTime" class="end-time">
                                                <el-time-select
                                                        placeholder="结束时间"
                                                        v-model="ruleForm.DailyEndTime"
                                                        :picker-options="{start: '00:00',step: '01:00',end: '23:00',minTime: startTime}">
                                                </el-time-select>
                                            </el-form-item>
                                        </div>
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

<script>
    import user from './user'
    export default {
        ...user
    }
</script>

<style>
.accountstate{
  line-height:40px;
}
.stateno{
   color:#333;
}
.statefail{
   color:red;
}
.statesuccess{
	color:green;
}
 .personinfo{
    margin:0 !important;
    width:720px;
 }
 .personinfo .el-textarea{
    width:610px !important;
 }
 .personinfo .el-select{
     width:100px !important;
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
	width:200px;
}
.time-div {
    display: flex;
}
.time-div .end-time .el-form-item__content{
    margin-left: 20px!important;
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
.personinfo .el-form-item__error{
    padding-top:0px !important;
}
.personinfo .el-form-item.desc .el-form-item__label,.personinfo .el-form-item.range .el-form-item__label{
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
.zbname{
	line-height:40px;
}
.shstate i{
	cursor:default;
	margin-left:10px;
}
.shstate .el-icon-success{
	color:green;
}
.shstate .el-icon-error{
	color:red;
}
</style>
