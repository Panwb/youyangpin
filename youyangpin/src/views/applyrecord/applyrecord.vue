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
                            <p class="title">申请记录</p>
                            <div class="content">
                                <!--申请记录-->
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
                                        <div class="title5">是否需要退样</div>
                                        <div class="title6">审核状态</div>
                                    </div>
                                    <div class="contentbox" v-if="pageList.length>0" v-for="(item,index) in pageList" :key="index">
                                        <div class="topbox">
                                            <div class="date">{{ item.datetime }}</div><!--todo-->
                                            <div class="shop"><span :class="item.ShopType=='淘宝店'?'icon icon-tao':'icon icon-tian'"></span>{{ item.ShopName }}</div>
                                            <div class="wechat">微信号:{{ item.WeChat }}</div>
                                            <div class="phone">联系电话:{{ item.LinkmanPhone }}</div>
                                        </div>
                                        <div class="bottombox clear" v-for="(good,index) in item.Goods" :key="index">
                                            <div class="infobox">
                                                <div class="imgbox"><a :href="good.GoodsURL" target="view_window"><img :src="good.GoodsImgURL"></a></div>
                                                <div class="con">
                                                    <p class="name">{{ good.GoodsName }}</p>
                                                    <p class="price">直播专享价:<span class="num">{{ good.LivePrice }}</span> <span class="normal">日常价:{{ good.DailyPrice }}</span></p>
                                                    <p class="money">佣金比例:<span class="num">{{ good.CommissionRatio }}%</span></p>
                                                    <p class="date">活动日期：{{ formatDate(good.ActivityBeginTime) }}-{{ formatDate(good.ActivityEndTime) }}</p>
                                                    <p class="detail">{{ good.IsProvideMulticolor === '是' ?  '提供多色（' + good.ColorNum + '中颜色）' : '' }}</p>
                                                </div>
                                            </div>
                                            <div class="salenum">{{ good.Sales }}</div>
                                            <div class="leavenum">{{ good.InventoryNum }}</div>
                                            <div class="quan">
                                               <div class="outer">
                                                 <div class="inner">
                                                  {{ good.PreferentialWay ==='拍下立减'?'拍下立减':good.DailyPrice-good.LivePrice+'元优惠券' }}
                                                  </div>
                                                </div>
                                            </div>
                                            <div class="needsendback"><span>{{ good.NeedSendBack }}</span></div>
                                        </div>
                                        <div class="option">
                                          <div class="outer">
                                            <div class="box inner">
                                                <span class="passno" v-if="item.CheckStatus === '待审核'">{{ item.CheckStatus }}</span>
                                                <span class="passsuccess" v-if="item.CheckStatus === '审核通过'">{{ item.CheckStatus }}</span>
                                                <span class="passfail" v-if="item.CheckStatus === '审核不通过'">{{ item.CheckStatus }}</span>
                                            </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="pagebox">
                                        <el-pagination @size-change="handleSizeChange" @current-change="handleCurrentChange" :current-page.sync="pageIndex" :page-size="itemsPerPage" layout="prev, pager, next, jumper" :total="total">
                                        </el-pagination>
                                    </div>
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
    import applyrecord from './applyrecord'
    export default {
        ...applyrecord
    }
</script>

<style scoped>
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
	height:147px;
	line-height:147px;
	float:left;
	border-bottom: 1px solid #ebeef5;
}
.bottombox .needsendback{
    width:188px;
    text-align:center;
    font-size:14px;
    height:147px;
    line-height:147px;
    float:left;
    border-bottom: 1px solid #ebeef5;
}
.bottombox .quan{
    width:100px;
    text-align:center;
    font-size:14px;
    height:147px;
    float:left;
    border-bottom: 1px solid #ebeef5;
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
.option{
    position: absolute;
    right: 0;
    width: 172px;
    top: 37px;
    bottom: 0px;
    border-left: 1px solid #ebeef5;
    text-align: center;
    border-bottom: 1px solid #ebeef5;
}
.option button:first-child{
    margin-top:25px;
}
.option button{
    width:100%;
    padding:0;
    margin:0 0 10px 0;
    display:block;
}
.option .outer{
    height:100%;
    width:100%;
    display:table;
}
.quan .outer{
    height:100%;
    width:100px;
    display:table;
}
.option .inner,.quan .inner{
    height:100%;
    display:table-cell;
    vertical-align: middle;
}
.topbox>div.shop{
    padding-left:40px;
    margin-left:0;
}
.topbox>div.shop .icon{
    position: absolute;
    top: 6px;
    left: 13px;
    width: 22px;
    height: 22px;
}
.topbox>div.shop .icon-tian{
    background: url(~assets/images/pro.png) -162px 0 no-repeat;
}
.topbox>div.shop .icon-tao{
    background: url(~assets/images/pro.png) -162px -28px no-repeat;
}
.passno{
   color:#333;
}
.passfail{
   color:red;
}
.passsuccess{
    color:green;
}
</style>
