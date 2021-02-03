using AvaliacaoTecnica;
using AvaliacaoTecnica.Domain;
using System;
using Xunit;

namespace Tests
{
    public class ProcessTreeTests
    {
        [Theory]
        [InlineData("A,B")]
        public void ProcessTree_TwoNodesTwoLevel_Success(params string[] treeNodes)
        {
            var result = Program.ProcessTree(treeNodes);
            var expected = @$"A[{Environment.NewLine}[B]{Environment.NewLine}]";

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("B,D", "D,E", "A,B", "C,F", "E,G", "A,C")]
        public void ProcessTree_SevenNodesOneChildEach_Success(params string[] treeNodes)
        {
            var result = Program.ProcessTree(treeNodes);
            var expected = @$"A[{Environment.NewLine}[B[D[E[G]]]]{Environment.NewLine}[C[F]]{Environment.NewLine}]";

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("A,B", "A,C", "B,G", "C,H", "E,F", "B,D", "C,E")]
        public void ProcessTree_EightNodesFourLevels_Success(params string[] treeNodes)
        {
            var result = Program.ProcessTree(treeNodes);
            var expected = @$"A[{Environment.NewLine}[B[D][G]]{Environment.NewLine}[C[E[F]][H]]{Environment.NewLine}]";

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("U,Z", "W,Y", "R,W", "S,U", "Q,S", "P,Q", "S,T", "W,X", "P,R", "U,V")]
        public void ProcessTree_ElevenNodesFiveLevels_Success(params string[] treeNodes)
        {
            var result = Program.ProcessTree(treeNodes);
            var expected = @$"P[{Environment.NewLine}[Q[S[T][U[V][Z]]]]{Environment.NewLine}[R[W[X][Y]]]{Environment.NewLine}]";

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("A,B", "A,C", "B,G", "C,H", "E,F", "B,D", "C,E", "B,K")]
        public void ProcessTree_MoreThanTwoChildren_ThrowE1Exception(params string[] treeNodes)
        {
            Func<string> functionReference = () => Program.ProcessTree(treeNodes);

            var exception = Assert.Throws<TreatedException>(functionReference);
            Assert.Equal("E1", exception.Code);
        }

        [Theory]
        [InlineData("A,B", "A,C", "B,D", "D,C")]
        public void ProcessTree_CyclicalReference_ThrowE2Exception(params string[] treeNodes)
        {
            Func<string> functionReference = () => Program.ProcessTree(treeNodes);

            var exception = Assert.Throws<TreatedException>(functionReference);
            Assert.Equal("E2", exception.Code);
        }

        [Theory]
        [InlineData("A,B", "A,C", "B,G", "C,H", "E,F", "B,D")]
        public void ProcessTree_MultipleRoots_ThrowE3Exception(params string[] treeNodes)
        {
            Func<string> functionReference = () => Program.ProcessTree(treeNodes);

            var exception = Assert.Throws<TreatedException>(functionReference);
            Assert.Equal("E3", exception.Code);
        }

        [Theory]
        [InlineData("")]
        public void ProcessTree_EmptyInput_ThrowSystemException(params string[] treeNodes)
        {
            Func<string> functionReference = () => Program.ProcessTree(treeNodes);

            var exception = Assert.ThrowsAny<Exception>(functionReference);
        }
    }
}
