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
							<p class="title">运费申请</p>
							<div class="content">
								<!--运费申请-->
								<div class="applybox">
									<el-form :model="freightData" :rules="rules" ref="freightData" label-width="150px">
										<el-form-item class="myitem" label="您的支付宝账号：" :rules="{ required: true, message: '请输入支付宝账号', trigger: 'blur' }" prop="AlipayAccount">
											<el-input v-model="freightData.AlipayAccount" placeholder="请输入支付宝账号"></el-input>
										</el-form-item>	
										<el-form-item class="myitem" label="当前可提现金额：" prop="AccountBalance">
											<span class="num">{{ freightData.AccountBalance }}元</span>
										</el-form-item>									
										<el-form-item class="myitem btnitem" >
											<div class="btnbox">
												<el-button class="applybtn" 
													:class="freightData.AccountBalance>100 && freightData.AlipayAccount?'active':''" 
													@click="applyClick">申请提现
												</el-button>
												<el-dialog :visible.sync="dialogVisible" width="30%">
													<span>确认要提现吗？</span>
													<span slot="footer" class="dialog-footer">
														<el-button @click="dialogVisible = false">取 消</el-button>
														<el-button type="primary"  @click="requestMoney('freightData')">确 定</el-button>
												    </span>
												</el-dialog>
											</div>
										</el-form-item>
									</el-form>
									<div class="btnbox">
										<span class="tipbox">（*可提现金额超过100元才能提现）</span>
									</div>
								</div>
								
								<template>
									<p class="txtitle">提现记录</p>
									<el-table :data="tableData"  style="width: 100%" class="freightbox">
										<el-table-column prop="ApplyTime" :formatter="format" label="申请时间"></el-table-column>
										<el-table-column prop="WithdrawalMoney" label="申请金额"></el-table-column>
										<el-table-column prop="HandleTime" :formatter="format" label="处理时间"></el-table-column>
										<el-table-column prop="HandleStatus" label="处理状态"></el-table-column>
										<el-table-column
									      fixed="right"
									      label="操作"
									      width="100">
									      <template slot-scope="scope">
									        <a :href="'/api/Withdrawal/ExportDetail?withdrawalId=' + scope.row.WithdrawalId" target="view_window">下载明细</a>
									      </template>
									  	</el-table-column>
									</el-table>
								</template>
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
    import freight from './freight'
    export default {
        ...freight
    }
</script>

<style>
.freightbox{
	margin-bottom:40px;
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
  margin-bottom:40px;
}
.applybox div span{
	font-size:14px;
}
.applybox .moneybox .num{
	color:red;
}
.applybox .applybtn{
	background:#ccc;
	color:#fff;
	border:none;
	padding:10px 20px;
	float:left;
	margin-left:20px;
}
.applybox .applybtn:hover{
	color:#fff;
	opacity:0.8;
}
.applybox .applybtn.active{
	background:#f9513b;
}
.applybox .applybtn.active{
	background:#f9513b;
}
.applybox .tipbox{
	font-size:12px;
	color:#f9513b;
	margin-top:15px;
	margin-left:10px;
	float:left;
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
.txtitle{
	color: #f9513b;
	font-weight:bold;
	font-size:16px;
	margin-bottom:15px;
}
.el-table th{
	background:#f5f5f5;
	color:#333;
}
.el-table th,.el-table td{
	text-align:center;
}
.applybox{
    width: 300px;
    margin: 0 auto 15px;
    padding: 20px;
    margin-bottom:15px;
}
.zfid{
	width: 120px;
    display: inline-block;
    vertical-align: middle;
    height: 30px;
}
.zfid .el-input__inner{
	height: 30px;
    line-height: 30px;
}
.freightbox.el-table td, .freightbox.el-table th{
	text-align:left;
}
.applybox .el-form-item.myitem{
	margin-bottom:5px !important;
}
.applybox .el-form-item.myitem .el-form-item__content{
	margin-bottom:0 !important;
}
.applybox .el-form-item.btnitem .el-form-item__content{
	margin-left:0 !important;
}
.applybox .el-form-item.myitem  .el-input{
	margin-bottom:0 !important;
}
.applybox .tipbox{
	position: relative;
    top: -37px;
    left: 120px;
}
</style>
