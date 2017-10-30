using System;
using System.Collections.Generic;
using System.Text;

namespace CZZD.ERP.Common
{
    public class CConstant
    {
        #region 数据库数据状态
        //初始
        public static int INIT = 0;

        //正常
        public static int NORMAL = 1;

        //删除
        public static int DELETE = 9;

        //暂停
        public static int PAUSE = 5;
        #endregion

        #region Master 工具条
        //新建
        public static int MODE_NEW = 1;

        //复制
        public static int MODE_COPY = 2;

        //编辑
        public static int MODE_MODIFY = 3;

        //删除
        public static int MODE_DELETE = 4;

        //查询
        public static int MODE_SEARCH = 5;

        //导出
        public static int MODE_EXPORT = 6;

        //关闭
        public static int MODE_CANCEL = 7;

        #endregion

        #region 基础数据查询页面分页标准，大于MAX_MASTER_PAGE_SIZE后分页查询
        //基础数据查询页面分页标准，大于MAX_MASTER_PAGE_SIZE后分页查询
        public static int MAX_MASTER_PAGE_SIZE = 16;
        #endregion

        #region 审核状态

        //0: 未审核  
        public static int UN_VERIFY = 0;

        //1：审核通过
        public static int VERIFY = 1;

        //2：审核未通过
        public static int NO_VERIFY = 2;

        #endregion

        #region　引当状态
        //未引当
        public static int ALLOATION_UN = 0;

        //引当完了
        public static int ALLOATION_COMPLETE = 1;

        //引当欠品
        public static int ALLOATION_PART = 2;

        //引当出库
        public static int ALLOATION_SHIPMENT = 3;

        #endregion

        #region　出库状态
        //未出库
        public static int UN_SHIPMENT = 0;

        //出库完了
        public static int COMPLETE_SHIPMENT = 1;

        //出库欠品
        public static int PART_SHIPMENT = 2;
        #endregion

        #region 入荷状态
        //未入荷
        public static int UN_RECEIPT = 0;

        //入荷完了
        public static int COMPLETE_RECEIPT = 1;

        //入荷欠品
        public static int PART_RECEIPT = 2;

        #endregion

        #region 采购订单

        //新采购订单
        public static int PURCHASE_NEW = 0;

        //全部入库
        public static int PERCHASE_NORMAL = 1;

        //删除
        public static int PURCHASE_DELETE = 9;

        //采购订单修改
        public static int PURCHASE_MODIFY = 3;

        //详细确认
        public static int PURCHASE_SEARCH = 4;

        #endregion

        #region 采购订单查询
        //新建
        public static string PURCHASE_ORDER_NEW = "0";
        //修正
        public static string PURCHASE_ORDER_MODIFY = "1";
        //普通查询
        public static string PURCHASE_ORDER_SEARCH = "2";
        //MASTER 查询
        public static string PURCHASE_ORDER_MASTER_SEARCH = "3";

        #endregion

        #region　附件
        //无附件
        public static int NO_ATTACHED = 0;

        //有附件
        public static int EXIST_ATTACHED = 1;

        #endregion

        #region 操作类型
        //新建
        public static string ORDER_NEW = "0";
        //订单查询 /详细信息
        public static string ORDER_SEARCH = "1";

        //在库引当
        public static string ORDER_ALLOATION = "2";

        //订单修正 
        public static string ORDER_MODIFY = "3";

        //订单承认  
        public static string ORDER_VERIFY = "4";

        //复制订单 
        public static string ORDER_COPY = "5";

        //订单历史记录
        public static string ORDER_HISTORY = "6";

        //订单MasterSearch
        public static string ORDER_MASTER_SEARCH = "7";

        //订单修理
        public static string ORDER_SERVICE = "8";

        //生产确认
        public static string PRODUCT_VALIDATION = "9";

        //报价单
        public static string ORDER_QOUTATION = "10";

        #endregion

        #region 附件目录
        //销售
        public static string ATTACHE_DIRECTORY_ORDER = "ORDER";

        //采购
        public static string ATTACHE_DIRECTORY_PURCHASE = "PURCHASE";

        //报价
        public static string ATTACHE_DIRECTORY_QUOTATION = "QUOTATION";


        //报价
        public static string ATTACHE_DIRECTORY_PRODUCTION = "PRODUCTION";
        #endregion

        #region 库存修改 状态

        public static string STOCK_RECEIVING_PLAN_LIST = "RECEIVING_PLAN";

        public static string STOCK_ALLOATION_LIST = "ALLOATION";

        public static string INVENTORY_SEARCH = "1";

        public static string INVENTORY_END = "2";
        #endregion

        #region 盘点状态
        public static int INIT_INVENTORY = 0;

        public static int COMPLETE_INVENTORY = 1;

        public static int ALREADY_INVENTORY = 2;
        #endregion

        #region 组成状态
        //组成
        public static int BUILD_STATUS = 1;

        //解除
        public static int RELIEVE_STATUS = 2;
        #endregion

        #region NMAES类型
        public static string NMAE_STATUS = "MaintenanceStations";
        #endregion

        #region  预收款区分
        //收款
        public static int DEPOSIT = 1;

        //退款
        public static int RE_DEPOSIT = 2;
        #endregion

        #region　导出EXCEL的返回状态

        //导出失败
        public static int EXPORT_FAILURE = 0;

        //导出成功
        public static int EXPORT_SUCCESS = 1;

        //文件正在运行，重新生成文件失败
        public static int EXPORT_RUNNING = 2;

        //模版文件不存在
        public static int EXPORT_TEMPLETE_FILE_NOT_EXIST = 3;

        //导出取消
        public static int EXPORT_CANCEL = 4;

        #endregion

        #region 报表类型
        //OEM销售成绩表
        public static string INVOICE_OEM_SALES = "0";

        //OEM制品管理表
        public static string INVOICE_OEM_PRODUCT = "1";

        //应收账款管理表
        public static string INVOICE_ACCOUNT_RECEIVABLE = "2";

        //进销存汇总表
        public static string INVOICE_SUMMARY = "3";

        #endregion

        #region 默认对比货币
        //人民币
        public static string EXCHANGE_CHIAN = "01";

        //日币
        public static string EXCHANGE_JAPAN = "02";
        #endregion

        #region 导出表头
        //PURCHASE_ORDER
        public static string PURCHASE_ORDER_HEADER = "采购订单编号,采购订单日期,采购订单区分,销售订单编号,报价单号,供应商,公司,入库仓库,交货期限,总额," +
                                                     "税率,货币,包装方式,支付方式,订单备注,状态,订单行号,商品,采购数量,单位,单价,不含税金额,税金,含税金额,创建人员,创建时间," +
                                                     "最后更新时间,最后更新人";
        public static string PURCHASE_ORDER_COLUMNS = "SLIP_NUMBER, SLIP_DATE, SLIP_TYPE, ORDER_SLIP_NUMBER, SUPPLIER_ORDER_CODE, SUPPLIER_NAME,COMPANY_NAME,WAREHOUSE_NAME,DUE_DATE," +
                                                      "TOTAL_AMOUNT,TAX_RATE,CURRENCY_NAME,PACKING_METHOD,PAYMENT_CONDITION,MEMO,STATUS_FLAG1,LINE_NUMBER,PRODUCT_NAME,QUANTITY,UNIT_NAME," +
                                                      "PRICE,AMOUNT_WITHOUT_TAX,TAX_AMOUNT,AMOUNT_INCLUDED_TAX,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_TIME,LAST_UPDATE_USER";

        //PURCHSE_ORDER_SUPPLEMENT
        public static string PO_SUPPLEMENT_HEADER = "仓库编号,仓库名称,商品编号,商品名称,机器型号,单位,安全在库数,在库数,最大在库数,最小采购数,状态,创建人,创建时间,最后更新人,最后更新时间";
        public static string PO_SUPPLEMENT_COLUMNS = "WAREHOUSE_CODE,WAREHOUSE_NAME,PRODUCT_CODE,PRODUCT_NAME,MODEL_NUMBER,UNIT_NAME,SAFETY_STOCK,QUANTITY,MAX_QUANTITY,MIN_PURCHASE_QUANTITY,STATUS_FLAG,CREATE_NAME,CREATE_DATE_TIME,LAST_UPDATE_NAME,LAST_UPDATE_TIME";

        //ORDER
        public static string ORDER_HEADER = "公司名称,销售编号,销售日期,销售区分,机器编号,公司销售编号,合同编号,客户名称,出库仓库名称," +
                                            "出库预定日期,货币名称,销售预付款,出库预付款," +
                                            "含税金额,税率,税金,出库状态,检查编号,检查日期,备注," +
                                            "明细编号,商品名称,数量,单位,单价,明细金额,明细备注";
        public static string ORDER_COLUMNS = "COMPANY_NAME,SLIP_NUMBER,SLIP_DATE,SLIP_TYPE,SERIAL_NUMBER,OWNER_PO_NUMBER,CUSTOMER_PO_NUMBER,ENDER_CUSTOMER_NAME,WAREHOUSE_NAME," +
                                             "DEPARTUAL_DATE,CURRENCY_NAME,ORDER_DEPOSIT,SHIPMENT_DEPOSIT," +
                                             "AMOUNT_INCLUDED_TAX,TAX_RATE,TAX_AMOUNT,SHIPMENT_NAME,CHECK_NUMBER,CHECK_DATE,MEMO," +
                                             "LINE_NUMBER,PRODUCT_NAME,LINE_QUANTITY,UNIT_NAME,PRICE,AMOUNT,MEMO";

        //SHIPMENT
        public static string SHIPMENT_HEADER = "出库编号,订单编号,机器序列号,公司,出库日期,交货期限,出库总金额,货币,状态,含税金额,不含税金额,税率,税金,出库行号,销售明细编号," +
                                               "出库仓库,商品,出库数量,单位,单价,出库金额,出库明细备注,创建人员,创建时间,最后更新人,最后更新时间";
        public static string SHIPMENT_COLUMNS = "SLIP_NUMBER, ORDER_SLIP_NUMBER, SERIAL_NUMBER, COMPANY_NAME, SLIP_DATE, ARRIVAL_DATE, AMOUNT, CURRENCY_NAME, STATUS_FLAG," +
                                                "AMOUNT_INCLUDED_TAX, AMOUNT_WITHOUT_TAX, TAX_RATE, TAX_AMOUNT, LINE_NUMBER, ORDER_LINE_NUMBER,DEPARTUAL_WAREHOUSE_NAME," +
                                                "PRODUCT_NAME, QUANTITY, UNIT_NAME, PRICE, LINE_AMOUNT, MEMO,CREATE_USER_NAME, CREATE_DATE_TIME, LAST_UPDATE_USER_NAME, LAST_UPDATE_TIME";
        //RECEIPT
        public static string RECEIPT_HEADER = "入库编号,采购订单编号,公司,状态,入库明细编号,入库日期,发票编号,入库仓库编号,入库仓库名称,供应商编号,供应商名称," +
                                              "商品名称,采购数量,入库数量,单位,单价,税率,货币名称,含税金额,不含税金额,税金,创建人,创建时间,最后更新人,最后更新时间";
        public static string RECEIPT_COLUMNS = "SLIP_NUMBER,PO_SLIP_NUMBER,COMPANY_NAME,STATUS_FLAG,LINE_NUMBER,SLIP_DATE,INVOICE_NUMBER,RECEIPT_WAREHOUSE_CODE,WAREHOUSE_NAME,SUPPLIER_CODE,SUPPLIER_NAME," +
                                               "PRODUCT_NAME,PURCHASE_QUANTITY,QUANTITY,UNIT_NAME,PRICE,TAX_RATE,CURRENCY_NAME,AMOUNT_INCLUDED_TAX,AMOUNT_WITHOUT_TAX,TAX_AMOUNT,CREATE_NAME,LAST_UPDATE_NAME,CREATE_DATE_TIME,LAST_UPDATE_TIME";

        //STOCK
        public static string STOCK_HEADER = "仓库编号,仓库名称,商品编号,商品名称,商品规格,单位编号,单位名称,在库数,安全在库数";
        public static string STOCK_COLUMNS = "WAREHOUSE_CODE,WAREHOUSE_NAME,PRODUCT_CODE,PRODUCT_NAME,SPEC,UNIT_CODE,UNIT_NAME,QUANTITY,SAFETY_STOCK";

        //COAMPANY
        public static string COMPANY_HEADER = "公司编号,公司名称,公司简称,英文名称,邮编,地址1,地址2,地址3,电话,传真," +
                                              "邮箱,公司网址,备注,状态,创建人员,创建时间,最后更新人,最后更新时间";
        public static string COMPANY_COLUMNS = "CODE,NAME,NAME_SHORT,NAME_ENGLISH,ZIP_CODE,ADDRESS_FIRST,ADDRESS_MIDDLE,ADDRESS_LAST,PHONE_NUMBER,FAX_NUMBER," +
                                               "EMAIL,URL,MEMO,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_USER,LAST_UPDATE_TIME";

        //CUSTOMER
        public static string CUSTOMER_HEADER = "客户编号,客户名称,客户简称,英文名称,邮编,地址1,地址2,地址3," +
                                               "电话,传真,联系人电话,联系人名称,公司网址,邮箱,经营范围,所在地(英语),客户类型,是否请款公司,请款编号,请款公司名称," +
                                               "状态,创建人员,创建时间,最后更新人,最后更新时间";
        public static string CUSTOMER_COLUMNS = "CODE,NAME,NAME_SHORT,NAME_ENGLISH,ZIP_CODE,ADDRESS_FIRST,ADDRESS_MIDDLE,ADDRESS_LAST," +
                                                "PHONE_NUMBER,FAX_NUMBER,MOBIL_NUMBER,CONTACT_NAME,EMAIL,URL,MEMO,MEMO2,TYPE,CLAIM_FLAG,CLAIM_CODE,CLAIM_NAME," +
                                                "STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_USER,LAST_UPDATE_TIME";

        //CUSTOMER_PRICE
        public static string CUSTOMER_PRICE_HEADER = "客户编号,客户名称,商品编号,商品名称,单位编号,单位名称,销售价格,状态,创建人员,创建时间,最后更新人,最后更新时间";
        public static string CUSTOMER_PRICE_COLUMNS = "CUSTOMER_CODE,CUSTOMER_NAME,PRODUCT_CODE,PRODUCT_NAME,UNIT_CODE,UNIT_NAME,PRICE,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_USER,LAST_UPDATE_TIME";

        //DEPARTMENT
        public static string DEPARTMENT_HEADER = "部门编号,部门名称,上级部门编号,上级部门名称,公司编号,公司名称,状态,创建人员,创建时间,最后更新人,最后更新时间";
        public static string DEPARTMENT_COLUMNS = "CODE,NAME,PARENT_CODE,PARENT_NAME,COMPANY_CODE,COMPANY_NAME,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_USER,LAST_UPDATE_TIME";

        //LOCATION
        public static string LOCATION_HEADER = "货位编号,仓库编号,仓库名称,商品编号,商品名称,货位名称,状态,创建人员,创建时间,最后更新人,最后更新时间";
        public static string LOCATION_COLUMNS = "CODE,WAREHOUSE_CODE,WAREHOUSE_NAME,PRODUCT_CODE,PRODUCT_NAME,NAME,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_USER,LAST_UPDATE_TIME";

        //PRODUCT
        public static string PRODUCT_HEADER = "商品编号,商品名称,商品规格,机器型号,分类编号,分类名称,基础单位编号,基础单位名称,海关编号,海关名称,默认售价," +
                                              "采购价格,货位编号,货位名称,安全在库数,状态,创建人员,创建时间,最后更新人,最后更新时间";
        public static string PRODUCT_COLUMNS = "CODE,NAME,SPEC,MODEL_NUMBER,GROUP_CODE,GROUP_NAME,BASIC_UNIT_CODE,UNIT_NAME,HS_CODE,HSCODE_NAME,SALES_PRICE," +
                                               "PURCHASE_PRICE,LOCATION_CODE,LOCATION_NAME,SAFETY_STOCK,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_USER,LAST_UPDATE_TIME";

        //PRODUCT_GROUP
        public static string PRODUCT_GROUP_HEADER = "商品种类编号,商品种类名称,上级类别编号,上级类别名称,默认供应商,供应商2,供应商3,状态,创建人员,创建时间,最后更新人,最后更新时间";
        public static string PRODUCT_GROUP_COLUMNS = "CODE,NAME,PARENT_CODE,PARENT_NAME,BASIC_SUPPLIER_NAME,SECOND_SUPPLIER_NAME,THIRD_SUPPLIER_NAME,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_USER,LAST_UPDATE_TIME ";

        //PRODUCT_PARTS
        public static string PRODUCT_PARTS_HEADER = "组成品编号,组成品名称,材料编号,材料名称,数量,状态,创建人员,创建时间,最后更新人,最后更新时间";
        public static string PRODUCT_PARTS_COLUMNS = "PRODUCT_CODE,PRODUCT_NAME,PRODUCT_PART_CODE,PRODUCT_PART_NAME,QUANTITY,STATUS_FLAG,CREATE_NAME,CREATE_DATE_TIME,LAST_UPDATE_NAME,LAST_UPDATE_TIME";

        //REASON
        public static string REASON_HEADER = "编号,内容,公司,状态,创建人员,创建时间,最后更新人,最后更新时间";
        public static string REASON_COLUMNS = "CODE,NAME,COMPANY_CODE,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_USER,LAST_DATE_TIME";

        //ROLES
        public static string ROLES_HEADER = "编号,名称,备注,状态,创建人员,创建时间,最后更新人,最后更新时间";
        public static string ROLES_COLUMNS = "CODE,NAME,MEMO,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_USER,LAST_UPDATE_TIME";

        //SLIP_TYPE
        public static string SLIP_TYPE_HEADER = "编号,名称,公司名称,状态,创建人员,创建时间,最后更新人,最后更新时间";
        public static string SLIP_TYPE_COLUMNS = "CODE,NAME,COMPANY_NAME,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_USER,LAST_UPDATE_TIME";

        //MACHINE
        public static string MACHINE_HEADER = "机器编号,机器名称,材料编号,材料名称";
        public static string MACHINE_COLUMNS = "SLIP_TYPE_CODE,SLIP_TYPE_NAME,PRODUCT_GROUP_CODE,PRODUCT_GROUP_NAME";

        //SUPPLIER
        public static string SUPPLIER_HEADER = "供应商编号,供应商名称,供应商简称,英文名称,邮编,地址1,地址2,电话1,电话2,传真1,传真2,联系人电话,联系人名称," +
                                               "邮箱,公司网址,备注,供应商类型,是否付款公司,付款编号,状态,创建人员,创建时间,最后更新人,最后更新时间";
        public static string SUPPLIER_COLUMNS = "CODE,NAME,NAME_SHORT,NAME_ENGLISH,ZIP_CODE,ADDRESS_FIRST,ADDRESS_MIDDLE,PHONE_NUMBER,PHONE_NUMBER_LAST,FAX_NUMBER,FAX_NUMBER_LAST,MOBIL_NUMBER,CONTACT_NAME," +
                                                "EMAIL,URL,MEMO,TYPE,CLAIM_FLAG,CLAIM_CODE,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_USER,LAST_UPDATE_TIME";

        //SUPPLIER_PRICE
        public static string SUPPLIER_PRICE_HEADER = "供应商编号,供应商名称,商品编号,商品名称,单位编号,单位名称,采购价格,状态,创建人员,创建时间,最后更新人,最后更新时间";
        public static string SUPPLIER_PRICE_COLUMNS = "SUPPLIER_CODE,SUPPLIER_NAME,PRODUCT_CODE,PRODUCT_NAME,UNIT_CODE,UNIT_NAME,PRICE,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_USER,LAST_UPDATE_TIME";

        //TAX_RATE
        public static string TAX_RATE_HEADER = "编号,名称,税率,状态,创建人员,创建时间,最后更新人,最后更新时间";
        public static string TAX_RATE_COLUMNS = "CODE,NAME,TAX_RATE,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_USER,LAST_UPDATE_TIME";

        //UNIT
        public static string UNIT_HEADER = "单位编号,单位名称,状态,创建人员,创建时间,最后更新人,最后更新时间";
        public static string UNIT_COLUMNS = "CODE,NAME,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_USER,LAST_UPDATE_TIME";

        //USER
        public static string USER_HEADER = "用户编号,密码,用户名称,电话,邮箱,部门编号,部门名称,公司编号,公司名称,角色编号,角色名称,入职时间,离职时间,状态,创建人员,创建时间,最后更新人,最后更新时间";
        public static string USER_COLUMNS = "CODE,PASSWORD,NAME,PHONE,EMAIL,DEPARTMENT_CODE,DEPARTMENT_NAME,COMPANY_CODE,COMPANY_NAME,ROLES_CODE,ROLES_NAME,INT_COMMUNITY_DATE,OUT_COMMUNITY_DATE,STATUS_FLAG,CREATE_USER,CREATE_DATE,LAST_UPDATE_USER,LAST_UPDATE_TIME";

        //WAREHOUSE
        public static string WAREHOUSE_HEADER = "仓库编号,仓库名称,公司简称,邮编,地址1,地址2,地址3,电话,传真,联系人电话,联系人名称," +
                                                "邮箱,备注,状态,创建人员,创建时间,最后更新人,最后更新时间";
        public static string WAREHOSUE_COLUMNS = "CODE,NAME,NAME_SHORT,ZIP_CODE,ADDRESS_FIRST,ADDRESS_MIDDLE,ADDRESS_LAST,PHONE_NUMBER,FAX_NUMBER,MOBIL_NUMBER,CONTACT_NAME," +
                                                "EMAIL,MEMO,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_USER,LAST_UPDATE_TIME";

        //AVAILABILITY
        public static string AVAILABILITY_HEADER = "供应商编号,供应商名称,外购件编号,外购件名称,采购总额,采购数量,最高价格,最低单价," +
                                                   "平均单价,实际交货量,实际交货率,不良品数量,不良品率,准时交货量,准时交货率";
        public static string AVAILABILITY_COLUMNS = "SUPPLIER_CODE,SUPPLIER_NAME,PRODUCT_CODE,PRODUCT_NAME,PURCHASE_AMOUNT,PURCHASE_QUANTITY,MAX_PRICE,MIN_PRICE," +
                                                    "AVERAGE_PRICE,RECEIPT_QUANTITY,RECEIPT_RATE,RERECEIPT_QUANTITY,RERECEIPT_RATE,ON_SCHEDULE_RECEIPT_QUANTITY,ON_SCHEDULE_RECEIPT_RATE";
        //WEIGHT
        public static string WEIGHT_HEADER = "订单编号,工单编号,部件,工序,重量(KG)";
        public static string WEIGHT_COLUMNS = "ORDER_SLIP_NUNBER,SLIP_NUMBER,PARTS_NAME,PRODUCTION_PROCESS_NAME,WEIGHT";

        //SCHEDULE
        public static string SCHEDULE_HEADER = "生产状态,订单编号,客户名称,订单日期,交货日期,生产工单号,模具种类,生产通知时间,预定开始日期,预定结束日期,";
        public static string SCHEDULE_COLUMNS = " PRODUCTION_STATUS,ORDER_SLIP_NUNBER,BC_NAME,OH_SLIP_DATE,DEPARTUAL_DATE,SLIP_NUMBER,ST_NAME,CHECK_DATE,PLAN_START_DATE,PLAN_END_DATE";
       
        //TECHNOLOGY
        public static string TECHNOLOGY_HEADER = "生产工单编号,模具种类,部件,工序,技术,图纸,预定完成日期,加工结束日期";
        public static string TECHNOLOGY_COLUMNS = " SLIP_NUMBER,SLIP_TYPE_NAME,PARTS_NAME,PRODUCTION_PROCESS_NAME,BT_TECHNOLOGY_NAME,BTN_DOWN_LOAD,PST_PLAN_END_DATE,PST_ACTUAL_END_TIME";

        //PRODUCTION
        public static string PRODUCTION_HEADER = "生产工单编号,模具种类,部件,工序,图纸,技术,预定开始日期,预定结束日期,加工开始日期,加工结束日期,重量";
        public static string PRODUCTION_COLUMNS = " SLIP_NUMBER,SLIP_TYPE_NAME,PARTS_NAME,PRODUCTION_PROCESS_NAME,BTN_DOWN_LOAD,TECHNOLOGY_STATUS,PSPP_PLAN_START_DATE,PSPP_PLAN_END_DATE,PSPP_ACTUAL_START_TIME,PSPP_ACTUAL_END_TIME,WEIGHT";

        //DRAWING
        public static string DRAWING_HEADER = "生产工单编号,模具种类,图纸,预定开始日期,结束日期,状态";
        public static string DRAWING_COLUMNS = " PSDL_SLIP_NUMBER,SLIP_TYPE_NAME,NAME,PSDL_PLAN_END_DATE,PSDL_ACTUAL_END_TIME,Status";
              
        #endregion

        #region 商品的销售地点
        public static int ERP_FOREIGN_NUMBER = 1;//  国外

        public static int ERP_DOMESTIC_NUMBER = 2;//    国内

        public static int PRODUCT_SELL_CHINA = 1;//中国

        public static int PRODUCT_SELL_JAPAN = 2;//日本
        #endregion

        #region 商品的包装方式
        //单独包装
        public static int PRODUCT_PACKAGE_ALONT = 1;
        //组合包装
        public static int PRODUCT_PACKAGE_COMPOSE = 2;
        #endregion

        #region 机械区分
        //机械本体
        public static int MECHANICAL_BASE = 1;

        //机械部件
        public static int MECHANICAL_PART = 2;
        #endregion

        #region 流水单号类型
        //销售
        public static string SEQ_ORDER = "SO";

        //采购
        public static string SEQ_PURCHASE_ORDER = "PO";

        //出库
        public static string SEQ_SHIPMENT = "SP";

        //入库
        public static string SEQ_RECEIPT = "RC";

        //返品
        public static string SEQ_RECEIPT_RETURN = "RR";
        #endregion

        #region 默认值
        /// <summary>
        /// 默认的订货到交货的时间
        /// </summary>
        public static int DEFAULT_LEAD_TIME = 7;

        /// <summary>
        /// 默认的税率
        /// </summary>
        public static decimal DEFAULT_RATE = 0.17M;

        /// <summary>
        /// 默认的货币
        /// </summary>
        public static string DEFAULT_CURRENCY_CODE = "01";

        /// <summary>
        /// 默认的源料仓库
        /// </summary>
        public static string DEFAULT_WAREHOUSE_CODE = "002";

        //默认的公司
        public static string DEFAULT_COMPANY_CODE = "01";

        #endregion

        #region 入库区分
        //入库
        public static string RECEIPT = "1";

        //临时入库
        public static string RECEIPT_TEMPORARY_STORAGE = "2";

        //返品入库
        public static string RECEIPT_REVERSE_STORAGE = "3";
        #endregion

        #region 商品区分
        //规格型号
        public static int PRODUCT_FLAG_SPEC = 1;

        //外购件
        public static int PRODUCT_FLAG_PURCHASE = 2;

        //自制件
        public static int PRODUCT_FLAG_PRODUCE = 3;

        //原料
        public static int PRODUCT_FLAG_PARTS = 4;
        #endregion

        #region 生产Flag
        //默认
        public static int PRODUCE_DEFAULT = 0;

        //生产确认
        public static int PRODUCE_SURE = 1;

        //自动采购Complete
        public static int AUTO_PURCHASE_COMPLETED = 2;

        //领料单确认
        public static int REQUISITION_CONFIRMATION = 3;

        //领料完成
        public static int REQUISITION_FINISH = 4;
        #endregion

        #region 采购类型
        //需求采购
        public static string PURCHASE_NEED = "NEED_PURCHASE";

        //售后维修
        public static string PURCHASE_REPAIRS = "REPAIRS";

        //其他采购
        public static string PURCHASE_OTHERS = "OTHERS_PURCHASE";
        #endregion

        #region 返品区分
        //采购返品
        public static int PURCHASE_RETURN = 1;

        //生产返品
        public static int PRODUCE_RETURN = 2;
        #endregion

        #region 报价单
        //新建
        public static string QUOTATION_NEW = "0";

        //详细确认
        public static string QUOTATION_OPERATE = "1";

        //修改
        public static string QUOTATION_MODIFY = "2";
        #endregion

        //新建
        public static string PRODUCTIONPLAN_NEW = "0";

        //详细确认
        public static string PRODUCTIONPLAN_OPERATE = "1";

        //修改
        public static string PRODUCTIONPLAN_MODIFY = "2";


        public static int STATUS = 0;
        public static int STATUS_START = 1;
        public static int STATUS_END = 2;

        #region　语言选择
        /// <summary>
        /// 中文
        /// </summary>
        public static string LANGUAGE_CN = "CN";

        /// <summary>
        /// 英文
        /// </summary>
        public static string LANGUAGE_EN = "EN";

        #endregion

    }//end class
}
