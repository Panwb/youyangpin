<template>
    <div id="app">
        <el-container>
            <main-header @clickType="clickType" ref="head" @goToIndex="goToIndex"></main-header>
            <!-- main start -->
            <el-main class="indexcontent">
                <div class="wd1200">
                    <div class="typebox">
                        <div class="topbox">
                            <span class="lab" :class="index === vIndex ? 'active' : ''"
                                  v-for="(item, index) in statistics"
                                  :key="index"
                                  @click="clickVField(item.VerticalFieldCode,index)" >
                                {{ item.VerticalFieldCode }}(<i>{{item.Quantity}}</i>)
                            </span>
                        </div>
                        <div class="bottombox">
                            <el-row>
                                <el-col :span="1"><div class="grid-content title">筛选:</div></el-col>
                                <el-col :span="5">
                                    <div class="grid-content">
                                        <span class="name">价格:</span> 
                                        <el-input v-model="searchForm.lowDailyPrice"></el-input>
                                        <span class="fuhao">~</span>
                                        <el-input v-model="searchForm.highDailyPrice"></el-input>
                                    </div>
                                </el-col>
                                <el-col :span="5">
                                    <div class="grid-content">
                                        <span class="name">销量:</span> 
                                        <el-input v-model="searchForm.lowSales"></el-input>
                                        <span class="fuhao">~</span>
                                        <el-input v-model="searchForm.highSales"></el-input>
                                    </div>
                                </el-col>
                                <el-col :span="8">
                                    <div class="grid-content">
                                        <span class="name">佣金比例:</span>
                                        <el-input v-model="searchForm.lowCommissionRatio"></el-input>
                                        <span class="fuhao">~</span>
                                        <el-input v-model="searchForm.highCommissionRatio"></el-input> 
                                        <el-button @click="goodsSearch" class="sxbtn">筛选</el-button>
                                        <el-button @click="reset" class="sxbtn resetbtn">重置</el-button>
                                    </div>
                                </el-col>
                                <el-col :span="5">
                                    <div class="grid-content paixu"><span class="name">排序:</span>
                                        <ul>
                                            <li @click="clickSortField(0,'')" :class="sortValue===0?'active':''">默认</li>
                                            <li @click="clickSortField(1,'DailyPrice')" :class="sortValue===1?'active':''">价格</li>
                                            <li @click="clickSortField(2,'Sales')" :class="sortValue===2?'active':''">销量</li>
                                            <li @click="clickSortField(3,'CommissionRatio')" :class="sortValue===3?'active':''">佣金</li>
                                        </ul>
                                    </div>
                                </el-col>
                            </el-row>
                        </div>
                    </div>
                    <div class="listbox">
                        <el-row :gutter="20">
                            <el-col :span="6" v-for="(item,index) in pageList" :key="item.GoodsId">
                                <el-card :body-style="{ padding: '0px' }" shadow="hover">
                                    <a :href="item.GoodsURL" target="view_window">
                                        <span class="type"><i>{{ item.ActivityType }}商品</i></span>
                                        <img :src="item.GoodsImgURL" class="image"/>
                                        <div class="numbox">
                                            <div class="rcprice"><div class="inner">日常价：{{ item.DailyPrice.toFixed(2) }}</div></div>
                                            <div class="xl"><div class="inner">销量{{ item.Sales }}件</div></div>
                                        </div>
                                    </a>
                                    <div class="content">
                                        <p class="words"><span :class="item.ShopType=='淘宝店'?'icon icon-tao':'icon icon-tian'"></span>{{ item.GoodsName }}</p>
                                        <div class="middle">
                                            <span class="money">￥<i class="count">{{ item.LivePrice.toFixed(2) }}</i></span>
                                            <div class="price">
                                                <p class="count">￥{{ item.DailyPrice.toFixed(2) }}</p>
                                                <p class="state">直播价</p>
                                            </div>
                                            <div class="youhui jian">
                                                <span class="num">{{ (item.DailyPrice-item.LivePrice).toFixed(2) }}</span>
                                            </div>
                                        </div>
                                        <div class="bottom clearfix">
                                            <div class="moneybox">佣金：<span class="money">{{ item.CommissionRatio }}%</span></div> <router-link :to="'/apply?goodsId=' + item.GoodsId"><el-button class="button enterbtn">进店拿样</el-button></router-link>
                                        </div>
                                    </div>

                                </el-card>
                            </el-col>
                        </el-row>
                    </div>
                    <div class="pagebox">
                        <el-pagination @size-change="handleSizeChange" @current-change="handleCurrentChange" :current-page.sync="searchForm.pageIndex" :page-size="searchForm.itemsPerPage" layout="prev, pager, next, jumper" :total="total"></el-pagination>
                    </div>
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
    import index from './index'
    export default {
        ...index
    }
</script>

<style>
.indexcontent{
   background-color: #f2f2f2; 
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
.typebox{
   margin-bottom:20px;
   font-size:14px;
   color:#333;
   border:1px solid #e3e3e3;
}
.typebox .topbox{
   background:#fff;
   padding:10px;
}
.typebox .topbox .lab{
	margin-right:18px;
	cursor:pointer;
}
.typebox .topbox .lab:hover{
    color:#f84933;
}
.typebox .topbox .lab.active{
    color:#f84933;
}
.typebox .topbox i{
   font-style:normal;
    font-size:14px;
}
.typebox .bottombox{
	padding:7px 10px;
	background:#f5f5f5;
}
.typebox .bottombox .sxbtn{
	width:60px;
	height:30px;
	color:#fff;
	background:#f35f17;
	font-size:14px;
	border:none;
	text-align:center;
	padding:0;
	margin-left:8px;
}
.typebox .bottombox .resetbtn{
    background:#fff;
    color:#333;
}
.el-input__inner{
	height:30px;
	line-height:30px;
}
.typebox .bottombox .el-input{
	display:inline-block;
	width:65px;
	height:30px;
	line-height:30px;
}
.typebox .bottombox .el-input input{
	height:30px;
	line-height:30px;
}
.typebox .bottombox .fuhao{
	padding:0 8px;
}
.typebox .bottombox input{
	width:65px;
	height:28px;
	line-height:28px;
}
.typebox .bottombox .title{
	margin-top:7px;
}
.typebox .bottombox .word{
	margin-left:10px;
}
.typebox .bottombox .name{
    margin-right:5px;
}
.typebox .bottombox .paixu{
	text-align:right;
	margin-top:8px;
}
.typebox .bottombox ul{
	list-style:none;
	display:inline-block;
}
.typebox .bottombox li{
	display:inline-block;
	padding:0 8px;
	cursor:pointer;
}
.typebox .bottombox li:hover{
    color:#f84933;
}
.typebox .bottombox li.active{
	color:#f84933;
}
.typebox .bottombox i{
	font-style:normal;
	color:#999;
}
.listbox .el-card{
	position:relative;
    margin-bottom: 30px;
}
.listbox .el-card:hover{
	border:1px solid #f35f17;
}
.listbox .el-card .image{
   width:100%;
   height:288px;
}
.listbox .type{
    height: 55px;
    width: 44px;
    background: url(~assets/images/pro.png) -52px 0 no-repeat;
    display: block;
    position: absolute;
    right: 0;
    top: 0;
}
.listbox .type i{
	font-style: normal;
    color: #fff;
    font-size: 14px;
    text-align: center;
    width: 30px;
    display: block;
    margin-left: 6px;
    margin-top:2px;
}
.listbox .numbox{
	position:absolute;
	left:0;
	top:258px;
	height:30px;
	line-height:30px;
	color:#fff;
	font-size:14px;
	width:100%;
}
.listbox .numbox .rcprice{
	float:left;
	width:50%;
	background:rgba(26,27,29,.65);
    text-align:center;
}
.listbox .numbox .xl{
	float:right;
	width:50%;
	background:rgba(26,27,29,.9);
	text-align:center;
}
.listbox .numbox .xl .inner{
	padding-right:12px;
}
.listbox .el-card .content{
	position:relative;
}
.listbox .el-card .words{
	font-size: 14px;
    color: #333;
    padding: 12px;
    padding-left:42px;
    overflow: hidden;
    text-overflow: ellipsis;
    white-space: nowrap;
}
.listbox .el-card .icon{
	position: absolute;
    top: 11px;
    left: 13px;
    width: 22px;
    height: 22px;
}
.listbox .el-card .icon-tian{
	background: url(~assets/images/pro.png) -162px 0 no-repeat;
}
.listbox .el-card .icon-tao{
	background: url(~assets/images/pro.png) -162px -28px no-repeat;
}
.listbox .content{
	position:relative
}
.listbox .bottom{
    background:#f5f5f5;
    padding:12px;
    font-size:16px;
    color:#000;
    overflow:hidden;
    border-bottom:1px solid #d5d6d6;
}
.listbox .bottom .money{
	color:#be0812;
    font-size:18px;
}
.listbox .bottom .moneybox{
	float:left;
	margin-top:10px;
}
.listbox .middle{
	padding:12px;
	overflow:hidden;
    padding: 0 12px 5px;
}
.listbox .middle .money{
	color:#ff2e2e;
	font-size:16px;
	float:left;
}
.listbox .middle .money .count{
	font-size:22px;
	font-style:normal;
    color:#f9513b;
}
.listbox .middle .price .state {
    color:#f9513b;
}
.listbox .middle .price{
	float:left;
	margin-left:5px;
	margin-top:-2px;
}
.listbox .middle .price .count{
	color:#989898;
	text-decoration: line-through;
}
.listbox .middle .youhui{
	width:90px;
	height:26px;
	float:right;
	margin-top:5px;
	position:relative;
}
.listbox .middle .youhui.quan{
	background: url(~assets/images/quan.png) 0 0 no-repeat;
}
.listbox .middle .youhui.jian{
	background: url(~assets/images/pro.png) 0 -57px no-repeat;
}
.listbox .middle .youhui .num{
    position: absolute;
    left: 10px;
    top: 5px;
    color: #ff2e2e;
    font-size: 12px;
    
    text-align: center;
    display: block;
    width: 30px;
}
.listbox .bottom .enterbtn{
	width:100px;
	height:40px;
	line-height:40px;
	padding:0;
	border:none;
	background:#f35f17;
	color:#fff;
	font-size:16px;
	float:right;
}
.pagebox{
	text-align:center !important;
}
.pagebox .el-pager li,.pagebox{
	margin:0 5px;
}
.pagebox .el-pager li.number{
	border:1px solid #ddd;
}
.pagebox .el-pagination__total{
	margin-left:15px;
}
.pagebox .btn-prev,.pagebox .btn-next{
	border:1px solid #ddd;
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
</style>
